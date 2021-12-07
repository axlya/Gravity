using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GravityCalc;
using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;



namespace GravityData
{
    /// <summary>
    /// Клиент для связи с контроллерами S300 Siemens по протоколу OPC UA 
    /// </summary>
    public class OPCUA_SiemensClient : IController
    {
        private bool _isConnected = false;                              // установлено соединение с контроллером
        private int _timeOut = 250;                                     // таймаут пересылки данных (в мс)
        private ILogger _logger = null;                                 // логгер 
        private readonly UAClientHelperAPI myClientHelperAPI = null;
        private EndpointDescription mySelectedEndpoint = null;
        private Session mySession = null;
        //обновление данных
        private bool _stop = false;
        private static AutoResetEvent _generateDataEvent = new(true);
        private DataProvider _dataProvider = null;                      // провайдер данных

        public string Url { get; } = "opc.tcp://192.168.0.1";

        private Errors errors;

        public OPCUA_SiemensClient()
        {
            myClientHelperAPI = new();
            errors = new();
        }

        public OPCUA_SiemensClient(ILogger<OPCUA_SiemensClient> logger)
        {
            myClientHelperAPI = new();
            _logger = logger;
            errors = new();
            if (!errors.IsErrorListExists())
                WriteErrorLog("Не найден файл с описанием ошибок!");
        }

        public void SetDataProvider(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void SetLogger (ILogger logger)
        {
            _logger = logger;
        }
        public bool IsConnected()
        {
            return _isConnected;
        }

        private void WriteErrorLog(string text)
        {
            if (_logger != null)
                _logger.LogError(text);
            else
                Console.WriteLine(text);
        }

        private void WriteInfoLog(string text)
        {
            if (_logger != null)
                _logger.LogInformation(text);
            else
                Console.WriteLine(text);
        }

        public void SetData(ControllerDataIn dataIn)
        {
            if (_isConnected)
            {
                try
                {
                    WriteVal("ns=4;i=42", dataIn.GoJackUp.ToString());
                    WriteVal("ns=4;i=46", dataIn.GoJackDown.ToString());
                    WriteVal("ns=4;i=44", dataIn.GoCargoLeft.ToString());
                    WriteVal("ns=4;i=43", dataIn.GoCargoRight.ToString());
                    if (dataIn.ResetErrors == 1) //очистка ошибок
                    {
                        WriteVal("ns=4;i=60", "999");
                        errors.ClearAllErrors();
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }
        /// <summary>
        /// Установить сигнал для связи с контроллером
        /// </summary>
        public void SetConnectSignal()
        {
            if (_isConnected)
            {
                try
                {
                    WriteVal("ns=4;i=30", "2");
                }
                catch (Exception)
                {
                    _isConnected = false;
                    SendDisconnectSignal();
                }
            }
        }

        public void Start()
        {
            if (_dataProvider == null)
            {
                WriteErrorLog("Провайдер данных не установлен! Работа модуля прекращена\n");
                return;
            }

            Thread thread = new(new ThreadStart(GenerateDataProc));

            thread.Start();

        }
        public void Stop()
        {
            _stop = true;
        }

        void GenerateDataProc()
        {
            _generateDataEvent.WaitOne();

            while (!_stop)
            {
                if (!_isConnected)
                    Connect();
                if (_isConnected)
                {
                    ControllerDataOut controllerDataOut = new ControllerDataOut();
                    controllerDataOut.DefaultInit();

                    controllerDataOut.ConnectDevice = ReadVal("ns=4;i=30");
                    if (controllerDataOut.ConnectDevice == 2) //2 выставляется для контроллера, что есть связь
                        controllerDataOut.ConnectDevice = 1;
                    controllerDataOut.JackPos = ReadVal("ns=4;i=50");
                    controllerDataOut.CargoPos = ReadVal("ns=4;i=51");
                    controllerDataOut.SensorAngle = ReadVal("ns=4;i=54");
                    controllerDataOut.SensorDisbalance = ReadVal("ns=4;i=40");
                    controllerDataOut.SensorPower = ReadVal("ns=4;i=41");
                    controllerDataOut.PowerSystem = ReadVal("ns=4;i=31");
                    double val = (ReadVal("ns=4;i=60"));
                    errors.AddNewControllerError(val);
                    controllerDataOut.ErrorsList = errors.GetDictErrorList();
                    if(val != 0)
                        WriteVal("ns=4;i=60", (val+1000).ToString());

                    _dataProvider.SendData(controllerDataOut);

                    SetConnectSignal();
                }
                else
                    SendDisconnectSignal();
            
                Thread.Sleep(_timeOut);
            }
            _generateDataEvent.Set();

            Disconnect();
        }
        /// <summary>
        /// Уведомить о обрыве связи
        /// </summary>
        public void SendDisconnectSignal()
        {
            errors.ClearAllErrors();
            ControllerDataOut controllerDataOut = new ControllerDataOut();
            controllerDataOut.DefaultInit();
            _dataProvider.SendData(controllerDataOut);
            WriteErrorLog("Нет связи с контроллером! Попытка нового соединения...\n");
        }

        public void Disconnect()
        {
            _isConnected = false;
            if (mySession != null && !mySession.Disposed)
            {
                try
                {
                    myClientHelperAPI.Disconnect();
                    mySession = myClientHelperAPI.Session;

                    WriteInfoLog("Успешное отключение от контроллера");
                }
                catch
                {

                }
            }

        }

        public void Connect()
        {
            Disconnect();
            GetEndpoints();
            try
            {
                //Register mandatory events (cert and keep alive)
                myClientHelperAPI.KeepAliveNotification += new KeepAliveEventHandler(Notification_KeepAlive);
                myClientHelperAPI.CertificateValidationNotification += new CertificateValidationEventHandler(Notification_ServerCertificate);

                //Check for a selected endpoint
                if (mySelectedEndpoint != null)
                {
                    //Call connect
                    myClientHelperAPI.Connect(mySelectedEndpoint, false, "", "").Wait();
                    //Extract the session object for further direct session interactions
                    mySession = myClientHelperAPI.Session;
                    _isConnected = true;

                    WriteInfoLog("Успешное подключение к контроллеру");

                }
                else
                {
                    WriteErrorLog("Не удалось подключиться к Endpoint!\n");
                   // Connect();                    
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("Не удалось подключится к контроллеру по адресу " + Url + " Текст ошибки: " + ex.Message);
            }

        }

        public void GetEndpoints()
        {
            bool foundEndpoints = false;

            try
            {
                ApplicationDescriptionCollection servers = myClientHelperAPI.FindServers(Url);
                foreach (ApplicationDescription ad in servers)
                {
                    foreach (string url in ad.DiscoveryUrls)
                    {
                        try
                        {
                            EndpointDescriptionCollection endpoints = myClientHelperAPI.GetEndpoints(url);
                            foundEndpoints = foundEndpoints || endpoints.Count > 0;
                            foreach (EndpointDescription ep in endpoints)
                            {
                                //берем первый endpoint
                                mySelectedEndpoint = ep;
                                break;
                            }
                        }
                        catch (ServiceResultException sre)
                        {
                            //If an url in ad.DiscoveryUrls can not be reached, myClientHelperAPI will throw an Exception
                            WriteErrorLog(sre.Message+'\n');
                        }
                    }
                    if (!foundEndpoints)
                    {
                        WriteErrorLog("Не найдены EndPoints\n");                       
                    }
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message + '\n');
            }
        }

        public string ReadValToStr(string id)
        {
            List<String> nodeIdStrings = new List<String>();
            List<String> values = new List<String>();
            nodeIdStrings.Add(id);
            try
            {
                values = myClientHelperAPI.ReadValues(nodeIdStrings);
                return values.ElementAt<String>(0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message + '\n');
                SendDisconnectSignal();
            }

            return Defines.UNDEF_STR_VALUE;
        }

        public double ReadVal(string id)
        {
            string str = ReadValToStr(id);
            if (str != Defines.UNDEF_STR_VALUE)
                return Convert.ToDouble(str);
            else
            {
                WriteErrorLog("Ошибка чтения параметра " + id + '\n');
                return Defines.UNDEF_DBL_VALUE;
            }
        }



        public void WriteVal(string id, string text) 
        {
            if (_isConnected)
            {
                List<String> nodeIdStrings = new List<String>();
                List<String> values = new List<string>();
                nodeIdStrings.Add(id);
                values.Add(text);
                try
                {
                    myClientHelperAPI.WriteValues(values, nodeIdStrings);
                }
                catch (Exception ex)
                {
                    WriteErrorLog("Ошибка записи параметра " + id + ", сообщение: " + ex.Message + '\n');
                    SendDisconnectSignal();
                   // throw ex;
                }
            }
        }

        private void Notification_ServerCertificate(CertificateValidator cert, CertificateValidationEventArgs e)
        {
            e.Accept = true;
        }
        private void Notification_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            if (e.Status.StatusCode == StatusCodes.BadNoCommunication)
            {
                SendDisconnectSignal();
                _isConnected = false;
                Disconnect();
            }
        }

    }
}

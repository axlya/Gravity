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
        private ILogger _logger = null; // логгер 
        //private readonly string _moduleName = "[SiemensClient]";
        private UAClientHelperAPI myClientHelperAPI = null;
        private EndpointDescription mySelectedEndpoint = null;
        private Session mySession = null;
        //обновление данных
        private bool _stop = false;
        private static AutoResetEvent _generateDataEvent = new(true);
        //провайдер данных
        private DataProvider _dataProvider = null;

        public OPCUA_SiemensClient()
        {
            myClientHelperAPI = new();
        }

        public OPCUA_SiemensClient(ILogger<OPCUA_SiemensClient> logger)
        {
            myClientHelperAPI = new();
            _logger = logger;
        }

        public void SetDataProvider(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void SetLogger (ILogger logger)
        {
            _logger = logger;
        }

        private void WriteErrorLog(string text)
        {
            if (_logger != null)
                _logger.LogError(text);
            else
                Console.WriteLine(text);
        }

        public void SetData(ControllerDataIn dataIn)
        {
            WriteVal("ns=4;i=42", dataIn.GoJackUp.ToString());
            WriteVal("ns=4;i=46", dataIn.GoJackDown.ToString());
            WriteVal("ns=4;i=44", dataIn.GoCargoLeft.ToString());
            WriteVal("ns=4;i=43", dataIn.GoCargoRight.ToString());
        }

        public void Start()
        {
            Thread thread = new(new ThreadStart(GenerateDataProc));

            thread.Start();

        }
        public void Stop()
        {
            _stop = true;
        }

        void GenerateDataProc()
        {
            if (_dataProvider == null)
            {
                WriteErrorLog("Ошибка: DataProvider не установлен!\n");
                return;
            }

            _generateDataEvent.WaitOne();

            Connect();

            while (!_stop)
            {
                
                _dataProvider.SendData(new ControllerDataOut
                {
                    JackPos = ReadVal("ns=4;i=50"),
                    CargoPos = ReadVal("ns=4;i=51"),
                    SensorAngle = ReadVal("ns=4;i=54"),
                    SensorDisbalance = ReadVal("ns=4;i=40"),
                    SensorPower = ReadVal("ns=4;i=41"),

                    ConnectDevice = ReadVal("ns=4;i=30"),
                    PowerSystem = ReadVal("ns=4;i=52"),
                    Error = ReadVal("ns=4;i=53"),
                });
            

                Thread.Sleep(300);
            }
            _generateDataEvent.Set();

            Disconnect();
        }

        public string Url { get; } = "opc.tcp://192.168.0.1";



        public void Disconnect()
        {
            if (mySession != null && !mySession.Disposed)
            {
                try
                {
                    myClientHelperAPI.Disconnect();
                    mySession = myClientHelperAPI.Session;
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

                }
                else
                {
                     WriteErrorLog("Не удалось подключиться к Endpoint!\n");
                    Connect();
                    
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("" + ("Не удалось подключится к контроллеру по адресу {0}, код ошибки {1}\n", Url, ex.Message));
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
                        WriteErrorLog("Не найдены EndPoints");                       
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
            }

            return Defines.UNDEF_STR_VALUE;
        }

        public double ReadVal(string id)
        {
            string str = ReadValToStr(id);
            if (str != Defines.UNDEF_STR_VALUE)
                return Convert.ToDouble(str);
            else
                return Defines.UNDEF_DBL_VALUE;
        }

        public void WriteVal(string id, string text) 
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
                WriteErrorLog(ex.Message + '\n');
            }
        }

        private void Notification_ServerCertificate(CertificateValidator cert, CertificateValidationEventArgs e)
        {
            e.Accept = true;
        }
        private void Notification_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
                
        }
    }
}

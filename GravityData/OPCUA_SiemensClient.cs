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

        public string ServerUrl { get; set; }
        public string NamespaceUri { get; set; }

        public void CreateConnection()
        {
            m_Server = new UAClientHelperAPI();
            m_Server.CertificateValidationNotification += new CertificateValidationEventHandler(m_Server_CertificateEvent);
        }

        [Obsolete]
        public void ConnectToServer()
        {
            // Hook up to the KeepAlive event
            m_Server.KeepAliveNotification += new KeepAliveEventHandler(Notification_KeepAlive);

            // Connect to the server
            try
            {
                // Connect with URL from Server URL text box
                m_Server.Connect(ServerUrl, "none", MessageSecurityMode.None, false, "", "");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed:\n\n" + ex.Message);
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

            // Read Namespace Table
            try
            {
                List<string> nodesToRead = new List<string>();
                List<string> results = new List<string>();

                nodesToRead.Add("ns=0;i=" + Variables.Server_NamespaceArray.ToString());

                // Read the namespace array
                results = m_Server.ReadValues(nodesToRead);

                if (results.Count != 1)
                {
                    throw new Exception("Reading namespace table returned unexptected result");
                }

                // Try to find the namespace URI entered by the user
                string[] nameSpaceArray = results[0].Split(';');
                ushort i;
                for (i = 0; i < nameSpaceArray.Length; i++)
                {
                    if (nameSpaceArray[i] == NamespaceUri)
                    {
                        m_NameSpaceIndex = i;
                    }
                }

                // Check if the namespace was found
                if (m_NameSpaceIndex == 0)
                {
                    throw new Exception("Namespace " + NamespaceUri + " not found in server namespace table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading namespace table failed:\n\n" + ex.Message);
            }
        }

        private void Notification_ServerCertificate(CertificateValidator cert, CertificateValidationEventArgs e)
        {
            e.Accept = true;
        }
        private void Notification_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            // Connection handling not implemented
            ;
        }

    }
}

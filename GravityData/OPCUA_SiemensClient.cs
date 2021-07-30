using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;

namespace GravityData
{
    /// <summary>
    /// Клиент для связи с контроллерами S300 Siemens по протоколу OPC UA 
    /// </summary>
    class OPCUA_SiemensClient
    {
        private UAClientHelperAPI m_Server = null;
        private UInt16 m_NameSpaceIndex = 0;

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
        private void m_Server_CertificateEvent(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            // Accept all certificate -> better ask user
            e.Accept = true;
        }
        /// <summary>
        /// Event handling
        /// The function 
        /// - KeepAlive
        /// </summary>
        private void Notification_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            // Connection handling not implemented
            ;
        }
    }
}

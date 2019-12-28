using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace FlightSimulator.Model.Interface
{
    class ConnectToCommands 
    {
        private TcpClient client;
        NetworkStream stream;
        private volatile bool Connected;
        #region Singleton
        private static ConnectToCommands m_Instance = null;
        public static ConnectToCommands Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ConnectToCommands();
                }
                return m_Instance;
            }
        }
        private ConnectToCommands() { }
        #endregion
        public void connect()
        {
            
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP), 
                    ApplicationSettingsModel.Instance.FlightCommandPort);
                Console.WriteLine("Waiting for client connections...");
                client = new TcpClient();
                 client.Connect(ep);
                Console.WriteLine("Client connected");
            stream = client.GetStream();
                Connected = true;
        }

        public void disconnect()
        {
            Connected = false;
            client.Close();
        }



        public void write(string massege)
        {
            if(Connected)
            {
                Task task = new Task(() => {
                    
                    
                        //writer.Write(massege);
                        Byte[] data = System.Text.Encoding.ASCII.GetBytes(massege);
                        stream.Write(data, 0, data.Length);

                    
                });
                task.Start();
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using System.Net;
using System.Net.Sockets;
using FlightSimulator.Model;
using System.IO;

namespace FlightSimulator.Model
{
    class ConnectToInfo
    {
        private TcpListener listener;
        private bool isConnected = false;
        private TcpClient client;
        NetworkStream stream;
        StreamReader reader;

        #region Singleton
        private static ConnectToInfo m_Instance = null;
        public static ConnectToInfo Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ConnectToInfo();
                }
                return m_Instance;
            }
        }
        private ConnectToInfo() { }
        #endregion
        public void connect()
        {
            //Task t = new Task(() => { 
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP), 
                ApplicationSettingsModel.Instance.FlightInfoPort);
            listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for client connections...");
            client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");
            stream = client.GetStream();
            reader = new StreamReader(stream);
            isConnected = true;
            //});
        }

        public void disconnect()
        {
            isConnected = false;
            listener.Stop();
            client.Close();
            
        }

        

        

        public string read()
        {
            if(isConnected)
            {
                while (!client.Connected)
                {
                    System.Threading.Thread.Sleep(500);
                }
                string massege;
                
                    // in a loop - start after connect end in disconnect 
                    //massege = reader.Read(Encoding.ASCII.GetBytes());
                    massege = reader.ReadLine();
               
                return massege;
            }
            return "";
        }
    }
}

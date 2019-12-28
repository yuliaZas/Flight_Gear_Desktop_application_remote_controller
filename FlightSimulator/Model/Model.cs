using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using FlightSimulator.Model.EventArgs;
namespace FlightSimulator.Model

{
    public class Model
    {
        VirtualGeographicCocordinatesEventArgs geographicCocordinates = VirtualGeographicCocordinatesEventArgs.Instance;
        Task task;
        static ConnectToCommands commands = ConnectToCommands.Instance;
        ConnectToInfo info = ConnectToInfo.Instance;
        volatile bool run;
        #region Singleton
        private static Model m_Instance = null;
        public static Model Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Model();
                }
                return m_Instance;
            }
        }
        private Model() { }
        #endregion
        public void connect()
        {
            Task task = new Task(() => {
                info.connect();
                commands.connect();
            });
            task.Start();
            
            run = true;
        }
        public void disconnect()
        {
            run = false;
            task.Wait();
            info.disconnect();
            commands.disconnect();
        }
        public void start()
        {
             task = new Task(() => {
                connect();
                 Console.WriteLine("connected?>???");
                 while (run)
                 {
                     string infoo = info.read();
                     if(infoo.Length > 1)
                     {
                         string[] values = infoo.Split(',');
                         double lon = Convert.ToDouble(values[0]);
                         double lat = Convert.ToDouble(values[1]);
                         geographicCocordinates.updatePoint(lon,lat);
                         //geographicCocordinates.Latitude = Convert.ToDouble(values[1]);
                         //geographicCocordinates.Longitude = Convert.ToDouble(values[0]);
                     }
                     
                 }
            });
            task.Start();
        }
    }
}

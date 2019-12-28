using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model.EventArgs
{
    class VirtualSliderEventArgs
    {
        ConnectToCommands commands = ConnectToCommands.Instance;
        #region Singleton
        private static VirtualSliderEventArgs m_Instance = null;
        public static VirtualSliderEventArgs Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new VirtualSliderEventArgs();
                }
                return m_Instance;
            }
        }
        private VirtualSliderEventArgs() { }
        #endregion
        private double rudder;
        public double Rudder {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                string massege = "set controls/flight/rudder " + value + "\r\n";
                commands.write(massege);
            }
        }
        private double throttle;
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                string massege = "set controls/engines/current-engine/throttle " + value + "\r\n";
                commands.write(massege);
            }
        }
    }
}

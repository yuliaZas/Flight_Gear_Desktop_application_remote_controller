using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
namespace FlightSimulator.Model.EventArgs
{
    public class VirtualJoystickEventArgs
    {
        private ConnectToCommands commands = ConnectToCommands.Instance;
        #region Singleton
        /*private static VirtualJoystickEventArgs m_Instance = null;
        public static VirtualJoystickEventArgs Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new VirtualJoystickEventArgs();
                }
                return m_Instance;
            }
        }*/
        public VirtualJoystickEventArgs() { }
        #endregion

        private double aileron;
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                string massege = "set /controls/flight/aileron " + value + "\r\n";
                commands.write(massege);
            }
        }
        private double elevator;
        public double Elevator
        {
            get
            {
                return elevator;
            }

            set
            {
                elevator = value;
                string massege = "set controls/flight/elevator " + value + "\r\n";
                commands.write(massege);
            }
        }
    }
}
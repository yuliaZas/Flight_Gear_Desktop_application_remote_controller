using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace FlightSimulator.ViewModels
{
    public class MainWindowViewModel : BaseNotify
    {
        
        private Model.Model model;
        private Model.EventArgs.VirtualJoystickEventArgs joystickEventArgs = new Model.EventArgs.VirtualJoystickEventArgs();
        private Model.EventArgs.VirtualSliderEventArgs sliderEventArgs = Model.EventArgs.VirtualSliderEventArgs.Instance;
        //private Model.EventArgs.VirtualGeographicCocordinatesEventArgs geographicCocordinatesEventArgs;

        #region properties
        
        public double VM_Throttle
        {
            set
            {
                sliderEventArgs.Throttle = value;
            }
        }
        public double Aileron
        {
            set
            {
                joystickEventArgs.Aileron = value;
            }
        }
        public double Elevator
        {
            set
            {
                joystickEventArgs.Elevator = value;
            }
        }
        public double VM_Rudder
        {
            set
            {
                sliderEventArgs.Rudder = value;
            }
        }
        #endregion
        public MainWindowViewModel(Model.Model model)
        {
            this.model = model;
            
        }
        
        #region Commands
        #region ClickCommand
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => ConnectClick()));
            }
        }
        private void ConnectClick()
        {
            model.start();
            //model.disconnect();
        }
        #endregion
        #endregion
    }
}

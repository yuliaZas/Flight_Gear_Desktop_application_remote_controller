using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace FlightSimulator.ViewModels
{
    public abstract class BaseNotify : INotifyPropertyChanged
    {

        //for testing
        protected BaseNotify(double vM_Throttle, double vM_Rudder)
        {
            VM_Throttle = vM_Throttle;
            VM_Rudder = vM_Rudder;
        }

        protected BaseNotify()
        {
        }

       
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        // Properties
        private double modelThrottle;
        public double VM_Throttle
        {
            get { return modelThrottle; }
            set
            {
                //maby better to update a specific property in the model - like model.redder
                modelThrottle = value;
                /* update the correct methode in the command class
                model.FlightCommandPort.??
                */
                // notify that the property changed
                NotifyPropertyChanged("Throttle");
            }
        }
        
        private double modelRudder;

     
        public double VM_Rudder
        {
            get { return modelRudder; }
            set
            {
                //maby better to update a specific property in the model - like model.redder
                modelRudder = value;
                /* update the correct methode in the command class
                //model.FlightCommandPort.??
                */
                // notify that the property changed
                NotifyPropertyChanged("Rudder");
            }
        }
        
    }

}

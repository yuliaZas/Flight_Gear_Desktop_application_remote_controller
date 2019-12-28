using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //public Model.ApplicationSettingsModel model;

        //COTR - change it
        private double lon;
        private double lat;
        private Model.Model FBmodel;
        private Model.EventArgs.VirtualGeographicCocordinatesEventArgs FBgeographicCocordinates;
        public FlightBoardViewModel() : base()
        {
            FBmodel = Model.Model.Instance;            FBgeographicCocordinates = Model.EventArgs.VirtualGeographicCocordinatesEventArgs.Instance;
            FBgeographicCocordinates.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

        }

        public double VM_Lon
        {
            get
            {
                lon = FBgeographicCocordinates.Longitude;
                return lon;


            }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }

        }

        public double VM_Lat
        {
            get
            {
                lat = FBgeographicCocordinates.Latitude;
                return lat;
                
            }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }

        }

    }
}

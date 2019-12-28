using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulator.Model.EventArgs
{
    class VirtualGeographicCocordinatesEventArgs : INotifyPropertyChanged
    {
        #region Singleton
        private static VirtualGeographicCocordinatesEventArgs m_Instance = null;
        public static VirtualGeographicCocordinatesEventArgs Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new VirtualGeographicCocordinatesEventArgs();
                }
                return m_Instance;
            }
        }
        public VirtualGeographicCocordinatesEventArgs() { }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        public void updatePoint(double lon,double lat)
        {
            Longitude = lon;
            Latitude = lat;
            NotifyPropertyChanged("Lon");
        }

        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                //NotifyPropertyChanged("Lat");
            }
        }
        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
                //NotifyPropertyChanged("Lon");
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}

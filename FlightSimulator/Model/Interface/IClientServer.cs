using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    interface IClientServer
    {
        
         void connect();
         string read();
         void write(string massage);
         void disconnect();
    }
}

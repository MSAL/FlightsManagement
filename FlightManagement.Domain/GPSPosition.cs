using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Domain
{
    public class GPSPosition
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public GPSPosition(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}

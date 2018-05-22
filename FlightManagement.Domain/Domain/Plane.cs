using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Domain.Domain
{
    public class Plane
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int TakeOffEffort { get; set; }
        public List<Flight> Flights { get; set; }
    }
}

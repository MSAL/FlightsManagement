using FlightManagement.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightManagement.Web.UI.Models
{
    public class FlightModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Schedule { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Plane Plane { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public double FuelConsumption { get; set; }
       
    }
}
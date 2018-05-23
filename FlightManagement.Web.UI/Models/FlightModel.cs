using FlightManagement.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightManagement.Web.UI.Models
{
    public class FlightModel
    {
        public int Id { get; set; }
        [DisplayName("Flight Number")]
        public string Numero { get; set; }
        public int Schedule { get; set; }
        [DisplayName("Departure Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DepartureDate { get; set; }
        [DisplayName("Arrival Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ArrivalDate { get; set; }
        public Plane Plane { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public List<AirportModel> AirportList { get; set; }
        public double FuelConsumption { get; set; }


        public FlightModel()
        {
            AirportList = new List<AirportModel>();
        }

    }
}
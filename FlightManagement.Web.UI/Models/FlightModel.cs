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

        [DisplayName("Flight number")]
        public string Numero { get; set; }

        public int Schedule { get; set; }

        [DisplayName("Departure date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Arrival date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ArrivalDate { get; set; }

        [DisplayName("Aircraft refrence")]
        public PlaneModel Plane { get; set; }

        [DisplayName("Departure airport")]
        public AirportModel DepartureAirport { get; set; }

        [DisplayName("Arrival airport")]
        public AirportModel ArrivalAirport { get; set; }

        public List<AirportModel> AirportList { get; set; }

        public List<PlaneModel> PlaneList { get; set; }

        public double FuelConsumption { get; set; }


        public FlightModel()
        {
            AirportList = new List<AirportModel>();
            PlaneList = new List<PlaneModel>();
        }

    }
}
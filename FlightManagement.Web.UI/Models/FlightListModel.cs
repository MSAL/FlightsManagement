using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightManagement.Web.UI.Models
{
    public class FlightListModel
    {
        public FlightListModel()
        {
            flightList = new List<FlightModel>();
        }
        public List<FlightModel> flightList { get; set; }
    }
}
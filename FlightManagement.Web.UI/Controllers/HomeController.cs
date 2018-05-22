using FlightManagement.Domain.Domain;
using FlightManagement.IService.Airport;
using FlightManagement.IService.Flight;
using FlightManagement.IService.Plane;
using FlightManagement.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightManagement.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly IPlaneService _planeService;
        private readonly IFlightService _flightService;
        private readonly IAirportService _airport; 
        #endregion
        public HomeController(IPlaneService planeService,
                            IFlightService flightService, 
                            IAirportService airport
                            )
        {
            this._planeService = planeService;
            this._flightService = flightService;
            this._airport = airport;
        }
        public ActionResult Index()
        {
           this._planeService.Add(new Domain.Domain.Plane());
            //var flightList = this._flightService.GetAll();
           // prepareFlightModel(flightList);
            return View();
        }

        [NonAction]
        private List<FlightListModel> prepareFlightModel(List<Flight> flightList)
        {
            List<FlightListModel> flightListModel = new List<FlightListModel>();
            return flightListModel; 
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
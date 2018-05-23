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
    public class FlightController : Controller
    {
        #region Fields
        private readonly IPlaneService _planeService;
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        #endregion
        public FlightController(IPlaneService planeService,
                            IFlightService flightService,
                            IAirportService airportService
                            )
        {
            this._planeService = planeService;
            this._flightService = flightService;
            this._airportService = airportService;
        }
        // GET: Flight
        public ActionResult Index()
        {
            var flightList = new FlightListModel();
            
            flightList.flightList = prepareFlightListModel(_flightService.GetAll());
            return View(flightList.flightList);
        }


        /*this method can be replaced with AutoMapper*/
        [NonAction]
        private FlightModel preapreFlightModel(Flight flight)
        {
            var flightModel = new FlightModel();
            flightModel.Id = flight.Id;
            flightModel.Numero = flight.Numero;
            flightModel.Plane = preparePlaneModel(flight.Plane);
            flightModel.Schedule = flight.Schedule;
            flightModel.FuelConsumption = _flightService.FuelConsumption(flight);
            flightModel.DepartureAirport = prepareAirportModel(flight.DepartureAirport);
            flightModel.ArrivalAirport = prepareAirportModel(flight.ArrivalAirport);
            flightModel.DepartureDate = flight.DepartureDate;
            flightModel.ArrivalDate = flight.ArrivalDate;

            return flightModel; 
            
        }


        /*this method can be replaced with AutoMapper*/
        [NonAction]
        private List<AirportModel> prepareAirportListModel(List<Airport> airportList)
        {
            List<AirportModel> airportListModel = new List<AirportModel>();
            if (airportList != null)
            {
                foreach (var airport in airportList)
                {
                    airportListModel.Add(prepareAirportModel(airport));
                }
            }
            return airportListModel;
        }

        /*this method can be replaced with AutoMapper*/
        [NonAction]
        private AirportModel prepareAirportModel(Airport airport)
        {
            AirportModel airportModel = new AirportModel();
            if (airport != null)
            {
                airportModel.Id = airport.Id;
                airportModel.Name = airport.Name;

            }
            return airportModel;
        }

        /*this method can be replaced with AutoMapper*/
        [NonAction]
        private PlaneModel preparePlaneModel(Plane plane)
        {
            PlaneModel planModel = new PlaneModel();
            if (plane != null)
            {
                planModel.Id = plane.Id;
                planModel.Name = plane.Name;

            }
            return planModel;
        }


        /*this method can be replaced with AutoMapper*/
        [NonAction]
        private List<FlightModel> prepareFlightListModel(List<Flight> flightList)
        {
            FlightListModel flightListModel = new FlightListModel();
            if (flightList != null){
                foreach(var flight in flightList)
                {
                    flightListModel.flightList.Add(preapreFlightModel(flight));
                }
            }
            return flightListModel.flightList;
        }

        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            var flightModel = new FlightModel();
            flightModel.AirportList = prepareAirportListModel(_airportService.GetAll());
            return View(flightModel);
        }

        // POST: Flight/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int id)
        {
            FlightModel flightModel = preapreFlightModel(_flightService.GetById(id));
            return View();
        }

        // POST: Flight/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Flight flight =  _flightService.GetById(id);
                _flightService.Edit(flight);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flight/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _flightService.Delete(_flightService.GetById(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

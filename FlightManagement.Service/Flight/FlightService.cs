using FlightManagement.IService.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Domain.Domain;
using FlightManagement.IRepository.Flight;

namespace FlightManagement.Service.Flight
{
    public class FlightService : IFlightService
    {
        IFlightRepository _flightRepository; 

        public FlightService(IFlightRepository flightRepository)
        {
            this._flightRepository = flightRepository;
        }

        public void Add(Domain.Domain.Flight flight)
        {
            this._flightRepository.Add(flight);
        }

        public void Delete(Domain.Domain.Flight flight)
        {
            this._flightRepository.Delete(flight);
        }

        public void Edit(Domain.Domain.Flight flight)
        {
            this._flightRepository.Delete(flight);
        }

        public List<Domain.Domain.Flight> GetAll()
        {
            return this._flightRepository.GetAll();
        }

        public Domain.Domain.Flight GetById(int id)
        {
            return this._flightRepository.GetById(id);
        }

        public double GetDistance(Domain.Domain.Flight flight) {
            
            return this.Distance(flight.DepartureAirport.GPSPosition.Latitude,
                flight.DepartureAirport.GPSPosition.Longitude,
                flight.ArrivalAirport.GPSPosition.Latitude,
                flight.ArrivalAirport.GPSPosition.Longitude,
                'K' // KM
                ); 
        }

        public double GetDistance(Domain.Domain.Airport airportD, Domain.Domain.Airport airportA)
        {
            return this.Distance(airportD.GPSPosition.Latitude,
                airportD.GPSPosition.Longitude,
                airportA.GPSPosition.Latitude,
                airportA.GPSPosition.Longitude,
                'K' // KM
                );
        }

        public double FuelConsumption(Domain.Domain.Flight flight)
        {
            return  GetDistance(flight) / (flight.DepartureDate - flight.ArrivalDate).TotalSeconds + flight.Plane.TakeOffEffort;
           
        }

        #region Utility
        private double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2rad(lat1)) * Math.Sin(Deg2rad(lat2)) + Math.Cos(Deg2rad(lat1)) * Math.Cos(Deg2rad(lat2)) * Math.Cos(Deg2rad(theta));
            dist = Math.Acos(dist);
            dist = Rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        private double Deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double Rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
#endregion


    }
}

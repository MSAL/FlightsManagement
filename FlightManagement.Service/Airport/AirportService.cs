using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Domain.Domain;
using FlightManagement.IRepository;
using FlightManagement.IService.Airport;
using FlightManagement.IRepository.Airport;

namespace FlightManagement.Service.Airport
{
    public class AirportService : IAirportService
    {
        IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository)
        {
            this._airportRepository = airportRepository;
        }

        public void Add(Domain.Domain.Airport airport)
        {
            this._airportRepository.Add(airport); 
        }

        public void Delete(Domain.Domain.Airport airport)
        {
            this._airportRepository.Delete(airport);
        }

        public void Edit(Domain.Domain.Airport airport)
        {
            this._airportRepository.Edit(airport);
        }

        public List<Domain.Domain.Airport> GetAll()
        {
            return this._airportRepository.GetAll();
        }

        public Domain.Domain.Airport GetById(int id)
        {
            return this._airportRepository.GetById(id);
        }
    }
}

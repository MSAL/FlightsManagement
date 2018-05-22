using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.IService.Flight
{
    public interface IFlightService
    {
        List<Domain.Domain.Flight> GetAll();
        Domain.Domain.Flight GetById(int id);

        void Add(Domain.Domain.Flight flight);
        void Edit(Domain.Domain.Flight flight);
        void Delete(Domain.Domain.Flight flight);

        double GetDistance(Domain.Domain.Flight flight);
        double GetDistance(Domain.Domain.Airport airportA , Domain.Domain.Airport airportB);
        double FuelConsumption(Domain.Domain.Flight flight);
    }
}

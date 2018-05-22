using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Domain.Domain;

namespace FlightManagement.IRepository.Flight
{
    public interface IFlightRepository
    {
        List<Domain.Domain.Flight> GetAll();
        Domain.Domain.Flight GetById(int id);

        void Add(Domain.Domain.Flight flight);
        void Edit(Domain.Domain.Flight flight);
        void Delete(Domain.Domain.Flight flight);
    }
}

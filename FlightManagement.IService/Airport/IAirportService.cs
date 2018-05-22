using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Domain; 
namespace FlightManagement.IService.Airport
{
    public interface IAirportService
    {
        List<Domain.Domain.Airport> GetAll();
        Domain.Domain.Airport GetById(int id);

        void Add(Domain.Domain.Airport airport);
        void Edit(Domain.Domain.Airport airport);
        void Delete(Domain.Domain.Airport airport);
    }
}

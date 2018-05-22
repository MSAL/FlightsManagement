using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.IRepository.Plane
{
    public interface IPlaneRepository
    {
        List<Domain.Domain.Plane> GetAll();
        Domain.Domain.Plane GetById(int id);

        void Add(Domain.Domain.Plane plane);
        void Edit(Domain.Domain.Plane plane);
        void Delete(Domain.Domain.Plane plane);
    }
}

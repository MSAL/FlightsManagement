using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.IService;
using FlightManagement.IService.Plane;
using FlightManagement.IRepository.Plane;

namespace FlightManagement.Service.Plane
{
    public class PlaneService : IPlaneService
    {

        IPlaneRepository _planeRepository; 

        public PlaneService(IPlaneRepository planeRepository)
        {
            this._planeRepository = planeRepository;
        }

        public void Add(Domain.Domain.Plane plane)
        {
            this._planeRepository.Add(plane);
        }

        public void Delete(Domain.Domain.Plane plane)
        {
            this._planeRepository.Delete(plane);
        }

        public void Edit(Domain.Domain.Plane plane)
        {
            this._planeRepository.Edit(plane);
        }

        public List<Domain.Domain.Plane> GetAll()
        {
            return this._planeRepository.GetAll();
        }

        public Domain.Domain.Plane GetById(int id)
        {
            return this._planeRepository.GetById(id);
        }
    }
}

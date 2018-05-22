using FlightManagement.IRepository.Plane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Domain.Domain;
using FlightManagement.Domain.Contexte;
using System.Data.Entity.Validation;

namespace FlightManagement.Repository.Plane
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly FlightsDbContext _dbContext;

        public PlaneRepository(FlightsDbContext context)
        {
            this._dbContext = context;
        }

        public void Add(Domain.Domain.Plane plane)
        {
            try
            {
                if (plane == null)
                {
                    throw new ArgumentNullException("plane");
                }
                this._dbContext.Planes.Add(plane);
                this._dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public void Delete(Domain.Domain.Plane plane)
        {
            try
            {
                if (plane == null)
                    throw new ArgumentNullException("plane");

                this._dbContext.Planes.Remove(plane);

                this._dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public void Edit(Domain.Domain.Plane plane)
        {
            try
            {
                if (plane == null)
                    throw new ArgumentNullException("plane");

                this._dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public List<Domain.Domain.Plane> GetAll()
        {
            return _dbContext.Planes.ToList();
        }

        public Domain.Domain.Plane GetById(int id)
        {
            _dbContext.Flights.Find(id);
            return _dbContext.Planes.Find(id);
        }
    }
}

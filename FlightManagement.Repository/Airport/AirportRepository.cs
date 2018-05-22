using FlightManagement.IRepository.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Domain.Domain;
using FlightManagement.Domain.Contexte; 
using System.Data.Entity.Validation;

namespace FlightManagement.Repository.Airport
{
    public class AirportRepository : IAirportRepository
    {
        private readonly FlightsDbContext _dbContext;

        public AirportRepository(FlightsDbContext context)
        {
            this._dbContext = context; 
        }

        public void Add(Domain.Domain.Airport airport)
        {
            try
            {
                if (airport == null)
                {
                    throw new ArgumentNullException("airport");
                }
                this._dbContext.Airports.Add(airport); 
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

        public void Delete(Domain.Domain.Airport airport)
        {
            try
            {
                if (airport == null)
                    throw new ArgumentNullException("airport");


                this._dbContext.Airports.Remove(airport);

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

        public void Edit(Domain.Domain.Airport airport)
        {
            try
            {
                if (airport == null)
                    throw new ArgumentNullException("Flight");

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

        public List<Domain.Domain.Airport> GetAll()
        {
            return _dbContext.Airports.ToList();
        }

        public Domain.Domain.Airport GetById(int id)
        {
            return _dbContext.Airports.Find(id);
        }
    }
}

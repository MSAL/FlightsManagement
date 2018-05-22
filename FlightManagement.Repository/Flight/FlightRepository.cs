using FlightManagement.IRepository.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManagement.Domain;
using FlightManagement.Domain.Contexte;
using System.Data.Entity.Validation;

namespace FlightManagement.Repository.Flight
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightsDbContext _dbContext; 

        public FlightRepository(FlightsDbContext context)
        {
            this._dbContext = context; 
        }
        
        public void Add(Domain.Domain.Flight flight)
        {
            try
            {
                if (flight == null)
                {
                    throw new ArgumentNullException("flight");
                }
                _dbContext.Flights.Add(flight);
                _dbContext.SaveChanges();
            }
            catch(DbEntityValidationException dbEx)
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

        public void Delete(Domain.Domain.Flight flight)
        {
            try
            {
                if (flight == null)
                    throw new ArgumentNullException("flight");

                this._dbContext.Flights.Remove(flight);

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

        public void Edit(Domain.Domain.Flight flight)
        {
            try
            {
                if (flight == null)
                    throw new ArgumentNullException("flight");

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

        List<Domain.Domain.Flight> IFlightRepository.GetAll()
        {
            return _dbContext.Flights.ToList();
        }

        Domain.Domain.Flight IFlightRepository.GetById(int id)
        {
            _dbContext.Flights.Find(id);
            return _dbContext.Flights.Find(id);
        }
    }
}

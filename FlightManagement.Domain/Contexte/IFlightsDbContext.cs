using FlightManagement.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Domain.Contexte
{
    public interface IFlightsDbContext
    {
         DbSet<Airport> Airports { get; set; }
         DbSet<Plane> Planes { get; set; }
         DbSet<Flight> Flights { get; set; }
         DbSet<User> Users { get; set; }
    }
}

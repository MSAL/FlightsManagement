using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FlightManagement.Domain.Domain;

namespace FlightManagement.Domain.Contexte
{
    public class FlightsDbContext : DbContext
    {
        public FlightsDbContext() : base("FlightsDB")
        {

        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }


    }
}

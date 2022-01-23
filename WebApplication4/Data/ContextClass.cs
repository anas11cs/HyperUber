using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ContextClass : DbContext
    {
        public ContextClass() : base("DefaultConnection")
        {}
        // THE TABLES YOU WANT TO CREATE SHOULD BE DEFINED BELOW LIKE THIS
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Person> PersonRegistered { get; set; }
        public DbSet<UberRentedCars> UberRentedCarList { get; set; }
    }
}
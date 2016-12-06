using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore.CityApi.Entities
{
    public class CityInfoContext:DbContext
    {
        //2 way
        public CityInfoContext(DbContextOptions<CityInfoContext> options) 
            : base(options)
        {
            Database.EnsureCreated(); // if database has not create, then create it
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        // 1 way
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}

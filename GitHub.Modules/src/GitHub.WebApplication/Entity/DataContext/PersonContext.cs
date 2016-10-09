using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GitHub.WebApplication.Entity.Models;
using Microsoft.Extensions.Configuration;

namespace GitHub.WebApplication.Entity.DataContext
{
    public class PersonContext : DbContext
    {
        private IConfigurationRoot _config;

        public PersonContext(DbContextOptions options, IConfigurationRoot config) 
            : base(options)
        {
            _config = config;
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var temp = _config["ConnectionString:PeopleConnectionString"];
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionString:PeopleConnectionString"]);
        }
    }
}

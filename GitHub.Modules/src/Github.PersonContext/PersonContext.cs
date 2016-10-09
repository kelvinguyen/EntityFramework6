using GitHub.Models.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github.PersonContext
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localDB)\\MSSQLLocalDB;  Database= GitHubSearch;  Trusted_Connection=true;  MultipleActiveResultSets=true;");
        }
    }
}

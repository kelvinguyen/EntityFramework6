using NameSearch.Classes.Models;
using System.Data.Entity;


namespace NameSearch.DataContext.PersonContext
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Interest> Interests { get; set; }

    }
}

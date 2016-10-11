using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyst.Domain.Entities
{
    public class PersonContext : DbContext
    {
        private IConfigurationRoot _config;

        public PersonContext(IConfigurationRoot config, DbContextOptions<PersonContext> options) 
            : base(options)
        {
            _config = config;
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionString:connection"], b => b.MigrationsAssembly("Catalyst.Web"));
        }
    }
}

namespace NameSearch.Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NameSearch.Entity.PersonDataSeed;

    internal sealed class Configuration : DbMigrationsConfiguration<NameSearch.Entity.PersonContext.PersonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NameSearch.Entity.PersonContext.PersonContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.People.Any())
            {
                context.People.AddRange(DataSeed.CreateMultiplePerson());
            }
           
        }
    }
}

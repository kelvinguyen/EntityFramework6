using ASPCore.CityApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore.CityApi
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            //init seed data
            var cities = new List<City>()
            {
                new City()
                {
                    Name="New York City",
                    Description = "The One with that Big Park",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "The most visited urban park in the United State"
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "A 102 story skyscraoer locate in the Midtown Manhattan"
                        }
                    }
                },
                new City()
                {
                    Name="Paris City",
                    Description = "The One with that Big tower",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer"
                        },
                        new PointOfInterest()
                        {
                            Name = "The Louvre",
                            Description = "The world's largest museum"
                        }
                    }
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}

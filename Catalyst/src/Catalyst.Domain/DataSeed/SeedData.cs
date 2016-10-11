using Catalyst.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyst.Domain.DataSeed
{
    public class SeedData
    {
        private PersonContext _context;
        public SeedData()
        {

        }
        public SeedData(PersonContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Person.Any())
            {
               
                var person1 = new Person()
                {
                    FirstName = "Michael",
                    LastName = "Jackson",
                    Age = 35,
                    Address = new Address()
                    {
                        City = "las vegas",
                        PostalCode = "84234",
                        State = "Nevada",
                        Street = "3456 lunar lan"
                    },
                    Icon = new Image()
                    {
                        ImageUrl = "https://randomuser.me/api/portraits/women/4.jpg"          
                    },
                    Interests = new List<Interests>() {
                        new Interests() { Interest = "playing game" },
                        new Interests() { Interest = "singing" },
                        new Interests() { Interest = "dancing" }
                    }
                };

                var person2 = new Person()
                {
                    FirstName = "Michael",
                    LastName = " Phelp",
                    Age = 27,
                    Address = new Address()
                    {
                        City = "hulu",
                        PostalCode = "84138",
                        State ="TX",
                        Street = "34567 long beach"
                    },
                    Icon = new Image()
                    {
                        ImageUrl = "https://randomuser.me/api/portraits/women/12.jpg",
                    },
                    Interests = new List<Interests>() {
                        new Interests() { Interest = "Volley Ball" },
                        new Interests() { Interest = "Swimming" }
                    }
                };
                var person3 = new Person()
                {
                    FirstName = "Jackie",
                    LastName = "chan",
                    Age = 32,
                    Address = new Address()
                    {
                        City = "orange county",
                        PostalCode = "98765",
                        State = "CA",
                        Street = "56753 laguna beach"
                    },
                    Icon = new Image()
                    {
                        ImageUrl = "https://randomuser.me/api/portraits/men/63.jpg",
                    },
                    Interests = new List<Interests>() {
                        new Interests() { Interest = "acting" },
                        new Interests() { Interest = "singing" }
                    }
                };
                

                _context.Person.Add(person1);
                _context.Person.Add(person2);
                _context.Person.Add(person3);


                //save changes to DB
                await _context.SaveChangesAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalyst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalyst.Domain.Repos
{
    public class PersonRepos : IPersonRepos
    {
        private PersonContext _context;

        public PersonRepos(PersonContext context)
        {
            _context = context;
        }

      
        public IEnumerable<Person> GetPeople()
        {
            return _context.Person
                        .Include(t => t.Interests)
                        .Include(t => t.Address)
                        .Include(t => t.Icon)
                        .ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameSearch.Classes.Models;
using NameSearch.Entity.PersonContext;

namespace NameSearch.Repository.Repository
{
    class PersonRepos : IPersonRepos
    {
        private PersonContext _context;

        public PersonRepos(PersonContext context)
        {
            _context = context;
        }
        public List<Person> GetAllPeople()
        {
            
            return _context.People.ToList();
           
        }
    }
}

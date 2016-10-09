using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHub.WebApplication.Entity.DataContext;
using GitHub.WebApplication.Entity.Models;
using Microsoft.EntityFrameworkCore;




namespace GitHub.WebApplication.Entity.Repository
{
    public class PersonRepo:IPersonRepo
    {
        private PersonContext _context;

        public PersonRepo(PersonContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return _context.People.Include(p => p.Image)
                           
                          
                           .ToList();
        }
    }
}

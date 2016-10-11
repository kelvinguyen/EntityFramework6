using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameSearch.Classes.Models;
using NameSearch.DataContext.PersonContext;

namespace NameSearch.Repository.Repository
{
    public class PersonRepos : IPersonRepos
    {
        
        public List<Person> GetAllPeople()
        {
            using (var context = new PersonContext())
            {
                return context.People.ToList();
            }
               
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameSearch.Classes.Models;

namespace NameSearch.Repository.Repository
{
    public interface IPersonRepos
    {
        List<Person> GetAllPeople();
    }
}

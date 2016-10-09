using System.Collections.Generic;
using GitHub.WebApplication.Entity.Models;

namespace GitHub.WebApplication.Entity.Repository
{
    public interface IPersonRepo
    {
        IEnumerable<Person> GetAllPerson();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyst.Domain.Entities;

namespace Catalyst.Domain.Repos
{
    public interface IPersonRepos
    {
        IEnumerable<Person> GetPeople();
        Task<bool> SaveChangesAsync();
    }
}

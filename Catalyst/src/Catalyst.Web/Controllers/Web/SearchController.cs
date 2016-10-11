using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalyst.Domain.Repos;

namespace Catalyst.Web.Controllers.Web
{
    public class SearchController : Controller
    {
        private IPersonRepos _repos;

        public SearchController(IPersonRepos repos)
        {
            _repos = repos;
        }
        public IActionResult Index()
        {
            var people = _repos.GetPeople();
            return View(people);
        }
    }
}

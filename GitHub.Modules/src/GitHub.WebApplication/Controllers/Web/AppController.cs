using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHub.WebApplication.Entity.DataContext;
using GitHub.WebApplication.Entity.Repository;

namespace GitHub.WebApplication.Controllers.Web
{
    public class AppController : Controller
    {
        private IPersonRepo _repos;

        public AppController(IPersonRepo repos)
        {
            _repos = repos;
        }
        public IActionResult Index()
        {
            var people = _repos.GetAllPerson();
            return View();
        }
      
    }
}

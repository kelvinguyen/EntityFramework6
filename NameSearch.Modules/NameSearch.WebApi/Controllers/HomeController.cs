using NameSearch.Classes.Models;
using NameSearch.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NameSearch.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private IPersonRepos _repo;

        public HomeController(IPersonRepos repos)
        {
            _repo = repos;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            List<Person> list = _repo.GetAllPeople();
            return View();
        }
    }
}

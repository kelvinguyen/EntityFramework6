using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHub.WebApplication.Entity.Models;
using GitHub.WebApplication.Entity.Repository;
using Microsoft.EntityFrameworkCore;

namespace GitHub.WebApplication.Controllers.Api
{
    [Route("Github/People")]
    public class PersonController : Controller
    {
        private IPersonRepo _repos;

        public PersonController(IPersonRepo repos)
        {
            _repos = repos;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_repos.GetAllPerson());
        }
    }
}

using ASPCore.CityApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore.CityApi.Controllers
{
    public class DummyController : Controller
    {
        private CityInfoContext _ctx;
        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}

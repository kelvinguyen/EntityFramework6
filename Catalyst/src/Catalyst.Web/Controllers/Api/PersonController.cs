using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalyst.Domain.Repos;

namespace Catalyst.Web.Controllers.Api
{
    [Route("api/search")]
    public class PersonController : Controller
    {
        private IPersonRepos _repos;

        public PersonController(IPersonRepos repos)
        {
            _repos = repos;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {

                return Ok(_repos.GetPeople()    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

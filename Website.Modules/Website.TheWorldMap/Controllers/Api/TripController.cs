using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.TheWorldMap.Models;
using Website.TheWorldMap.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Website.TheWorldMap.Controllers.Api
{
    [Route("api/trips")]
    public class TripController : Controller
    {
        bool isSomethingBad = false;
        private ILogger<TripController> _logger;
        private IWorldRepository _repos;

        public TripController(IWorldRepository repos, ILogger<TripController> logger)
        {
            _repos = repos;
            _logger = logger;
        }


        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                if (isSomethingBad)
                    return BadRequest("bad thing happen");

                var result = _repos.GetAllTrips();
                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fail to get all trips {ex}");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]TripViewModel theTrip)
        {
            if (ModelState.IsValid)
            {
                var newTrip = Mapper.Map<Trip>(theTrip);
                _repos.AddTrip(newTrip);
                if (await _repos.SaveChangesAsync())
                {
                    return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }
                else
                {
                    return BadRequest("Failt to save change to database");
                }

               
            }
            return BadRequest(ModelState);
        }
    }
}
    
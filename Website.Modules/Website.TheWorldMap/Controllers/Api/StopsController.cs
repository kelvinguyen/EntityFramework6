using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.TheWorldMap.Models;
using AutoMapper;
using Website.TheWorldMap.ViewModels;

namespace Website.TheWorldMap.Controllers.Api
{
    [Route("api/trips/{tripname}/stops")]
    public class StopsController : Controller
    {
        private ILogger<StopsController> _logger;
        private IWorldRepository _repos;

        public StopsController(IWorldRepository repos, ILogger<StopsController> logger)
        {
            _repos = repos;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = _repos.GetTripByName(tripName);
                var stops = trip.Stops.OrderBy(s => s.Order).ToList();
                return Ok(Mapper.Map<IEnumerable<StopViewModel>>(stops)); 
            }
            catch (Exception ex)
            {

                _logger.LogError($"Fail to get Stop {ex}");
                return BadRequest($"Fail to get Stop {ex}");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(string tripName,[FromBody] StopViewModel vm)
        {
            try
            {              
                if (ModelState.IsValid)
                {
                    var newstop = Mapper.Map<Stop>(vm);

                    _repos.AddStop(tripName, newstop);
                    if (await _repos.SaveChangesAsync())
                    {
                        return Created($"api/trips/{tripName}/stops/{newstop.Name}",
                                   Mapper.Map<StopViewModel>(newstop));
                    }
                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fail to save stop {ex}");
            }
            return BadRequest($"Fail to add a stop to {tripName}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCore.CityApi.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        [HttpGet("{cityId}/PointsOfInterest")]
       public IActionResult GetPointsOfInterest(int cityId)
       {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            return Ok(city.PointsOfInterest);
       }

        [HttpGet("{cityId}/PointsOfInterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId,int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            var poi = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);
            if (poi == null)
                return NotFound();
            return Ok(poi);
        }
    }
}

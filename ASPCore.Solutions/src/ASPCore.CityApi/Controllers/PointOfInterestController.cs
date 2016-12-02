using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPCore.CityApi.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{cityId}/PointsOfInterest/{id}",Name ="GetPointOfInterest")]
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

        [HttpPost("{cityId}/PointsOfInterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            // SelectMany : add all PointOfInterests each city together into IEnumerable
            // Max : get the largest id value
            var id = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);
            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++id,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);
            /*
             * CreateAtRoute : will refer to header response [HttpGet("{cityId}/PointsOfInterest/{id}",Name ="GetPointOfInterest")]
             * 
             */
            return CreatedAtRoute("GetPointOfInterest",new { cityId = cityId,id=finalPointOfInterest.Id},finalPointOfInterest);
        }

        // this is full update : 
        [HttpPut("{cityId}/PointsOfInterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId,int id,
            [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
                return BadRequest();

            if (pointOfInterest.Name == pointOfInterest.Description)
                ModelState.AddModelError("Description", "Description should be different with Name");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);

            if (pointOfInterestFromStore == null)
                return NotFound();

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description; 

            return NoContent();
        }

        //partial update
        [HttpPatch("{cityId}/PointsOfInterest/{id}")]
        public IActionResult PartialUpdatePointOfInterest(int cityId,int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);

            if (pointOfInterestFromStore == null)
                return NotFound();

            
            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description
            };

            // updating section , add ModelState to check if we add some properties from body doesn't exist in our model
            // apply patch document to pointOfInterestToPatch
            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid) // this is the ModelState for JsonPatchDocumet not PointOfInterestUpdateDto
                return BadRequest(ModelState);
            // validate the PointOfInterestForUpdateDto
            if (pointOfInterestToPatch.Name == pointOfInterestToPatch.Description)
                ModelState.AddModelError("Description", "Description should be different with Name");

            TryValidateModel(pointOfInterestToPatch);
            if (!ModelState.IsValid) // this is the ModelState PointOfInterestUpdateDto
                return BadRequest(ModelState);
            
            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;


            return NoContent();
        }

        //delete resource
        [HttpDelete("{cityId}/PointsOfInterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var cities = CitiesDataStore.Current.Cities;
            if (cities == null)
                return BadRequest();
            var city = cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return BadRequest();
            var poi = city.PointsOfInterest;
            if (poi == null)
                return BadRequest();
            var poicity = poi.FirstOrDefault(c => c.Id == id);
            if (poicity == null)
                return BadRequest();
            poi.Remove(poicity);
            return NoContent();
        }
    }
}

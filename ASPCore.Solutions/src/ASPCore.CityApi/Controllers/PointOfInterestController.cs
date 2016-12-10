using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPCore.CityApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using ASPCore.CityApi.Services;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCore.CityApi.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        private ILogger<PointOfInterestController> _logger;
        private IMailService _mailService;
        private ICityInfoRepository _cityInfoRepo;

        public PointOfInterestController(ILogger<PointOfInterestController> logger,
                                         IMailService mailService, 
                                         ICityInfoRepository cityInfoRepo)
        {
            _logger = logger;
            _mailService = mailService;
            _cityInfoRepo = cityInfoRepo;
            //HttpContext.RequestServices.GetService(ILogger<PointOfInterestController>); --> use this to request service from container
        }

        [HttpGet("{cityId}/PointsOfInterest")]
       public IActionResult GetPointsOfInterest(int cityId)
       {
            try
            {
                //var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                
                if (!_cityInfoRepo.CityExists(cityId))
                {
                    _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of Interest");
                    return NotFound();
                }
                var pointsOfinterestForCity = _cityInfoRepo.GetPointsOfInterestForCity(cityId);
                //AutoMapper
                var pointsOfInterestForCityResult
                    = AutoMapper.Mapper.Map<IEnumerable<Models.PointOfInterestDto>>(pointsOfinterestForCity);
                return Ok(pointsOfInterestForCityResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}",ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
       }

        [HttpGet("{cityId}/PointsOfInterest/{id}",Name ="GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId,int id)
        {
            //var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            //if (city == null)
            //    return NotFound();
            //var poi = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);
            //if (poi == null)
            //    return NotFound();
            //return Ok(poi);



            
            if (!_cityInfoRepo.CityExists(cityId))
                return NotFound();
            var poi = _cityInfoRepo.GetPointOfInterestForCity(cityId, id);
            if (poi == null)
                return NotFound();
            //Code with AutoMapper
            var poiResult = AutoMapper.Mapper.Map<Models.PointOfInterestDto>(poi);
            //Code without AutoMapper
            //var poiResult = new PointOfInterestDto()
            //{
            //    Id = poi.Id,
            //    Name = poi.Name,
            //    Description = poi.Description
            //};
            return Ok(poiResult);
        }

        [HttpPost("{cityId}/PointsOfInterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
//coding Using AutoMapper
            var city = _cityInfoRepo.GetCity(cityId,true);
            if (!_cityInfoRepo.CityExists(cityId))
                return NotFound();
            var finalPointInterest = AutoMapper.Mapper.Map<Entities.PointOfInterest>(pointOfInterest);
            _cityInfoRepo.AddPointOfInterestForCity(cityId,finalPointInterest);
            if (!_cityInfoRepo.Save())
                return StatusCode(500, "A Problem happened while handling your request");
            var createPointOfInterestToReturn
                = AutoMapper.Mapper.Map<Models.PointOfInterestDto>(finalPointInterest);
            return CreatedAtRoute("GetPointOfInterest",
                                  new { cityId = cityId,id=createPointOfInterestToReturn.Id},
                                  createPointOfInterestToReturn);
            #region WithoutAutoMapper
            /* coding without AutoMapper
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

                         // CreateAtRoute : will refer to header response [HttpGet("{cityId}/PointsOfInterest/{id}",Name ="GetPointOfInterest")]
                        return CreatedAtRoute("GetPointOfInterest",new { cityId = cityId,id=finalPointOfInterest.Id},finalPointOfInterest);
            */
            #endregion
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

            if (!_cityInfoRepo.CityExists(cityId))
                return NotFound();

            var pointOfInterestFromStore = _cityInfoRepo.GetPointOfInterestForCity(cityId,id);

            if (pointOfInterestFromStore == null)
                return NotFound();

            AutoMapper.Mapper.Map(pointOfInterest, pointOfInterestFromStore);
            if (!_cityInfoRepo.Save())
                return StatusCode(500, "There is something in your request");

            return NoContent();
            #region Without EF
            /*
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
            */
            #endregion
        }

        //partial update
        [HttpPatch("{cityId}/PointsOfInterest/{id}")]
        public IActionResult PartialUpdatePointOfInterest(int cityId,int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            if (!_cityInfoRepo.CityExists(cityId))
                return NotFound();

            var pointOfInterestFromStore = _cityInfoRepo.GetPointOfInterestForCity(cityId,id);

            if (pointOfInterestFromStore == null)
                return NotFound();

            var pointOfInterestToPatch = AutoMapper.Mapper.Map<PointOfInterestForUpdateDto>(pointOfInterestFromStore);
          
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

            // AutoMapper.Mapper.Map(source,destination);
            AutoMapper.Mapper.Map(pointOfInterestToPatch,pointOfInterestFromStore);
            if (!_cityInfoRepo.Save())
                return StatusCode(500, "A problem while handling request");

            return NoContent();
            #region PartialUpdate without EF
            /*
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
            */
            #endregion
        }

        //delete resource
        [HttpDelete("{cityId}/PointsOfInterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            if (!_cityInfoRepo.CityExists(cityId))
                return BadRequest();
           
            var poi = _cityInfoRepo.GetPointOfInterestForCity(cityId,id);
            if (poi == null)
                return BadRequest();

            _cityInfoRepo.DeletePointOfInterest(poi);
            if (!_cityInfoRepo.Save())
                return StatusCode(500, "Request Error");

            _mailService.Send("Point of Interest deleted", $"Point of Interest {poi.Name} with id {poi.Id} was deleted");
            return NoContent();
            #region without EF
            /*
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

            _mailService.Send("Point of Interest deleted", $"Point of Interest {poicity.Name} with id {poicity.Id} was deleted");
            return NoContent();
            */
            #endregion
        }
    }
}

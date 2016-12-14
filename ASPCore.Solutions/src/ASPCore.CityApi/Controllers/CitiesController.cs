using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPCore.CityApi.Services;
using ASPCore.CityApi.Models;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCore.CityApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepo;
        public CitiesController(ICityInfoRepository cityInfoRepo)
        {
            _cityInfoRepo = cityInfoRepo;
        }
        [HttpGet()]
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepo.GetCities();
            //using AutoMapper
            var result = AutoMapper.Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);


            //this code is for without AutoMapper
            //var result = new List<CityWithoutPointsOfInterestDto>();
            //foreach (var cityEntity in cityEntities)
            //{
            //    result.Add(new CityWithoutPointsOfInterestDto() {
            //        Id = cityEntity.Id,
            //        Name = cityEntity.Name,
            //        Description = cityEntity.Description
            //    });
            //}
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetCity(int id, bool includePointOfInterest = false)
        {
            //var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == id);
            var cityToReturn = _cityInfoRepo.GetCity(id,includePointOfInterest);
            if (cityToReturn == null)
                return NotFound();

            if (includePointOfInterest)
            {
                //using AutoMapper
                var cityResult = AutoMapper.Mapper.Map<CityDto>(cityToReturn);
                //code without using AutoMapper
                //var cityResult = new CityDto()
                //{
                //    Id = cityToReturn.Id,
                //    Name = cityToReturn.Name,
                //    Description = cityToReturn.Description
                //};
                //foreach (var poi in cityToReturn.PointsOfInterest)
                //{
                //    cityResult.PointsOfInterest.Add(new PointOfInterestDto() {
                //        Id = poi.Id,
                //        Name = poi.Name,
                //        Description = poi.Description
                //    });
                //}
                return Ok(cityResult);
            }
            //Code with AutoMapper
            var cityResultWithoutPOI = AutoMapper.Mapper.Map<CityWithoutPointsOfInterestDto>(cityToReturn);
            // code without AutoMapper
            //var cityResultWithoutPOI = new CityWithoutPointsOfInterestDto()
            //{
            //    Id = cityToReturn.Id,
            //    Name = cityToReturn.Name,
            //    Description = cityToReturn.Description
            //};
            return Ok(cityResultWithoutPOI);
        }
    }
}

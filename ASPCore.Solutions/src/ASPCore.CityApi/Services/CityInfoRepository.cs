using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore.CityApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPCore.CityApi.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _cityInfoContext;
        public CityInfoRepository(CityInfoContext cityInfoContext)
        {
            _cityInfoContext = cityInfoContext;
        }
        public IEnumerable<City> GetCities()
        {
            return _cityInfoContext.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
                return _cityInfoContext.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId);

            return _cityInfoContext.Cities.FirstOrDefault(c => c.Id == cityId);
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            //return GetCity(cityId, true).PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            return _cityInfoContext.PointsOfInterest.FirstOrDefault(p => p.CityId == cityId && p.Id == pointOfInterestId);
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _cityInfoContext.PointsOfInterest.ToList();
        }
    }
}

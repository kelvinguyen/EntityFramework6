using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore.CityApi.Models;

namespace ASPCore.CityApi
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore(); 
        public List<CityDto> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDto>() {
                new CityDto() { Id=1,Name="New York City",Description="The one with the big park" ,
                                PointsOfInterest = new List<PointOfInterestDto>
                                {
                                    new PointOfInterestDto() { Id=2,Name="Antwerp",Description="The one with the catherdral that was never really finished" },
                                    new PointOfInterestDto() { Id=3,Name="Paris",Description="The one with that big tower" }
                                }
                              },
                new CityDto() { Id=2,Name="Antwerp",Description="The one with the catherdral that was never really finished" ,
                                 PointsOfInterest = new List<PointOfInterestDto>
                                {
                                    new PointOfInterestDto() { Id=2,Name="Antwerp",Description="The one with the catherdral that was never really finished" },
                                    new PointOfInterestDto() { Id=3,Name="Paris",Description="The one with that big tower" }
                                }
                              },
                new CityDto() { Id=3,Name="Paris",Description="The one with that big tower" ,
                                 PointsOfInterest = new List<PointOfInterestDto>
                                {
                                    new PointOfInterestDto() { Id=2,Name="Antwerp",Description="The one with the catherdral that was never really finished" },
                                    new PointOfInterestDto() { Id=3,Name="Paris",Description="The one with that big tower" }
                                }
                              }
            };
            
        }
    }
}

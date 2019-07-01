using AutoMapper;

namespace TWM.Api.Profiles
{
    public class GeoProfile : Profile
    {
        public GeoProfile()
        {

            CreateMap<Data.Domain.GeoEntities.Country, Business.Models.GeoEntities.CountryModelWithAssesments>();
            CreateMap<Data.Domain.GeoEntities.Country, Business.Models.GeoEntities.CountryModel>();

            CreateMap<Data.Domain.GeoEntities.Region, Business.Models.GeoEntities.RegionModel>();
            CreateMap<Data.Domain.GeoEntities.Region, Business.Models.GeoEntities.RegionWithCountryModel>();

            CreateMap<Data.Domain.GeoEntities.Continent, Business.Models.GeoEntities.ContinentModel>();
            CreateMap<Data.Domain.GeoEntities.Continent, Business.Models.GeoEntities.ContinentWithRegionsModel>();
            CreateMap<Data.Domain.GeoEntities.Continent, Business.Models.GeoEntities.ContinentWithRegionsAndCountriesModel>();

        }
    }
}

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
        }
    }
}

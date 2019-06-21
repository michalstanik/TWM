using AutoMapper;

namespace TWM.Api.Profiles
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithStatsModel>();

            CreateMap<Data.Domain.GeoEntities.Country, Business.Models.GeoEntities.CountryModelWithAssesments>();
            CreateMap<Data.Domain.GeoEntities.Country, Business.Models.GeoEntities.CountryModel>();

        }   
    }
}

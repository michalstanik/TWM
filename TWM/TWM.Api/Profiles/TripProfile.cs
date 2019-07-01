using AutoMapper;

namespace TWM.Api.Profiles
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Data.Domain.Trips.Trip, Business.Models.Trips.TripWithStatsModel>();
        }   
    }
}

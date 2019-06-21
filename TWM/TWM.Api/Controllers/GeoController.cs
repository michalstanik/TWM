using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TWM.Business.Models.GeoEntities;
using TWM.CoreHelpers.Attributes;
using TWM.Data.RepositoryInterfaces;

namespace TWM.Api.Controllers
{
    [Route("api/geo/")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        private readonly IGeoEntitiesRepository _geoRepository;
        private readonly IMapper _mapper;

        public GeoController(IGeoEntitiesRepository geoRepository, IMapper mapper)
        {
            _geoRepository = geoRepository;
            _mapper = mapper;
        }


        [HttpGet("GetCountriesForAllTrips", Name = "GetCountriesForAllTrips")]
        public async Task<ActionResult<List<CountryModel>>> GetCountriesForAllTrips()
        {
            try
            {
                var results = await _geoRepository.GetCountriesForAllTrips();
                var mapped = _mapper.Map<List<CountryModel>>(results);
                return mapped;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetCountriesForAllTripsWithAssessments", Name = "GetCountriesForAllTripsWithAssessments")]
        public async Task<ActionResult<List<CountryModelWithAssesments>>> GetCountriesForAllTripsWithAssessments()
        {
            try
            {
                var results = await _geoRepository.GetCountriesForAllTrips();
                var mapped = _mapper.Map<List<CountryModelWithAssesments>>(results);

                //TODO: Remove hardcoded user when authentication will be applied
                var user = "fec0a4d6-5830-4eb8-8024-272bd5d6d2bb";

                Dictionary<string, long> UserAssesment = await _geoRepository.GetCountireAssesmentForUser(user);

                foreach (var item in mapped)
                {
                    if (UserAssesment.ContainsKey(item.Alpha2Code))
                    {
                        item.AreaLevelAssessment = UserAssesment.GetValueOrDefault(item.Alpha2Code);
                    }
                    else
                    {
                        item.AreaLevelAssessment = 0;
                    }
                }

                return mapped;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetCountriesForTrip/{tripId}", Name = "GetCountriesForTrip")]
        public async Task<ActionResult<List<CountryModel>>> GetCountriesForTrip(int tripId)
        {
            try
            {
                var results = await _geoRepository.GetCountriesForTrip(tripId);
                var mapped = _mapper.Map<List<CountryModel>>(results);
                return mapped;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TWM.Business.Models.GeoEntities;
using TWM.CoreHelpers.Interfaces;
using TWM.Data.RepositoryInterfaces;

namespace TWM.Api.Controllers
{
    [Route("api/geo/")]
    [ApiController]
    //[Authorize]
    public class GeoController : ControllerBase
    {
        private readonly IGeoEntitiesRepository _geoRepository;
        private readonly IGeoAdminRepository _geoAdminRepository;
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfoService;

        public GeoController(IGeoEntitiesRepository geoRepository,IGeoAdminRepository geoAdminRepository, IMapper mapper, IUserInfoService userInfoService)
        {
            _geoRepository = geoRepository;
            _geoAdminRepository = geoAdminRepository;
            _mapper = mapper;
            _userInfoService = userInfoService;
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


        [HttpGet("GetCountriesForUserWithAssessments", Name = "GetCountriesForUserWithAssessments")]
        public async Task<ActionResult<List<CountryModelWithAssesments>>> GetCountriesForUserWithAssessments()
        {
            try
            {
                var results = await _geoRepository.GetCountiresWithAssesmentForUser(_userInfoService.UserId);
                var mapped = _mapper.Map<List<CountryModelWithAssesments>>(results);


                Dictionary<string, long> UserAssesment = await _geoRepository.GetCountireAssesmentForUser(_userInfoService.UserId);

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


        [HttpGet("GetCountriesForUserByContinent", Name = "GetCountriesForUserByContinent")]
        public async Task<ActionResult<List<ContinentWithRegionsAndCountriesModel>>> GetCountriesForUserByContinent()
        {
            try
            {
                var continentsFromRepo = await _geoAdminRepository.GetContinents(true, false);
                var mappedContinents
                    = _mapper.Map<List<ContinentWithRegionsAndCountriesModel>>(continentsFromRepo);
                
                var userCountries = await _geoRepository.GetCountiresWithAssesmentForUser(_userInfoService.UserId);
                var mappedUserCountries =
                    _mapper.Map<List<CountryModel>>(userCountries);

                foreach (var userCountry in mappedUserCountries)
                {
                    foreach (var item in mappedContinents)
                    {
                        foreach (var region in item.Regions)
                        {
                            region.TotalCountryCount = await _geoRepository.GetTotlCountryNumberForRegionName(region.Name);

                            if(region.Name == userCountry.RegionName)
                            {
                                region.Countries.Add(userCountry);
                                region.VisitedCountryCount += 1; 
                            }
                        }
                    }
                }

                return mappedContinents;

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
                
                Dictionary<string, long> UserAssesment = await _geoRepository.GetCountireAssesmentForUser(_userInfoService.UserId);

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

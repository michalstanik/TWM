using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TWM.Business.Models.GeoEntities;
using TWM.CoreHelpers.Attributes;
using TWM.CoreHelpers.Interfaces;
using TWM.Data.RepositoryInterfaces;

namespace TWM.Api.Controllers
{
    [Route("api/geo/admin/")]
    [ApiController]
    public class GeoAdminController : ControllerBase
    {
        private readonly IGeoAdminRepository _geoAdminRepository;
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfoService;

        public GeoAdminController(IGeoAdminRepository geoAdminRepository, IMapper mapper, IUserInfoService userInfoService)
        {
            _geoAdminRepository = geoAdminRepository;
            _mapper = mapper;
            _userInfoService = userInfoService;
        }


        [HttpGet("country")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.tripwme.continents+json" })]
        public async Task<IActionResult> GetAllContinents()
        {
            return await GetContinents<List<ContinentModel>>(false, false);
        }

        [HttpGet("country")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.tripwme.continentswithregions+json" })]
        public async Task<IActionResult> GetAllContinentsWithRegions()
        {
            return await GetContinents<List<ContinentWithRegionsModel>>(true, false);
        }

        [HttpGet("country")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.tripwme.continentswithregionsandcountries+json" })]
        public async Task<IActionResult> GetAllContinentsWithRegionsAndCountries()
        {
            return await GetContinents<List<ContinentWithRegionsAndCountriesModel>>(false, true);
        }

        private async Task<IActionResult> GetContinents<T>(bool includeRegions = false, bool includeCountries = false) where T : class
        {
            var tripFromRepo = await _geoAdminRepository.GetContinents(includeRegions, includeCountries);

            if (tripFromRepo == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<T>(tripFromRepo));
        }

    }
}

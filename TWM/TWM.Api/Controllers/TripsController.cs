using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWM.Business.Models.Trips;
using TWM.CoreHelpers.Attributes;
using TWM.Data.RepositoryInterfaces;

namespace TWM.Api.Controllers
{
    [Route("api/trips/")]
    [ApiController]
    [Authorize]
    public class TripsController : ControllerBase
    {
        private readonly ITripRepository _repository;
        private readonly IMapper _mapper;

        public TripsController(ITripRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.tripwme.tripwithstats+json" })]
        public async Task<ActionResult<List<TripWithStatsModel>>> GetAllTripsWithStats()
        {
            try
            {
                var includeStops = true;
                var includeUsers = true;

                var resultsFromRepo = await _repository.GetAllTripsAsync(includeStops, includeUsers);

                var resultsToBeReturned = new List<TripWithStatsModel>();

                foreach (var item in resultsFromRepo)
                {
                    var minDate = new DateTime();
                    var maxDate = new DateTime();

                    if (item.Stops.Count != 0)
                    {
                        minDate = item.Stops.Select(d => d.Arrival).Min().Date;
                        maxDate = item.Stops.Select(d => d.Arrival).Max().Date;
                    }

                    var newItem = new TripWithStatsModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        TripCode = item.TripCode,
                        TripStats = new TripStatsModel()
                        {
                            StopCount = item.Stops.Count,
                            CountryCount = item.Stops.Where(s => s.Location != null).Select(c => c.Location.CountryId).Distinct().Count(),
                            LocationCount = item.Stops.Where(s => s.Location != null).Select(c => c.Location.Id).Distinct().Count(),
                            UserCount = item.UserTrips.Where(t => t.TUser != null).Select(u => u.TUserId).Distinct().Count()
                        },
                        CountryCodes = item.Stops
                        .Where(s => s.Location != null)
                                .Select(c => c.Location)
                                .Where(v => v.CountryId != null)
                                .Select(c => c.Country)
                                .Select(c => c.Alpha3Code).Distinct().ToList().ConvertAll(d => d.ToLower()),
                        StartDate = minDate,
                        EndDate = maxDate
                    };
                    resultsToBeReturned.Add(newItem);
                }
                return resultsToBeReturned;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

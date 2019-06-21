using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWM.Data.Domain.GeoEntities;
using TWM.Data.Domain.Trips;
using TWM.Data.Domain.Users;
using TWM.Data.RepositoryInterfaces;

namespace TWM.Data.Repository
{
    public class GeoEntitiesRepository : IGeoEntitiesRepository
    {
        private readonly TripWMeContext _context;
        private readonly ILogger<GeoEntitiesRepository> _logger;

        public GeoEntitiesRepository(TripWMeContext context, ILogger<GeoEntitiesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Dictionary<string, long>> GetCountireAssesmentForUser(string userId)
        {
            Dictionary<string, long> countriesTobereturned = new Dictionary<string, long>();

            return countriesTobereturned = await _context.UserCountryAssessment
                .Where(a => a.TUser.Id == userId)
                .Select(a => new
                {
                    a.Country.Alpha2Code,
                    a.AreaLevelAssessment
                })
                .ToDictionaryAsync(p => p.Alpha2Code, p => p.AreaLevelAssessment);
        }

        public async Task<ICollection<Country>> GetCountriesForAllTrips()
        {
            var query = _context.Trip;

            var results = await ReturnCountriesBasedOnTripQuery(query);

            return results;
        }

        public async Task<ICollection<Country>> GetCountriesForTrip(int tripId)
        {
            var query = _context.Trip.Where(t => t.Id == tripId);

            var results = await ReturnCountriesBasedOnTripQuery(query);

            return results;
        }

        private async Task<ICollection<Country>> ReturnCountriesBasedOnTripQuery(IQueryable<Trip> inputQuery)
        {
            var listOfTripsWithGraph = inputQuery.Include(i => i.Stops)
                    .ThenInclude(l => l.Location)
                    .ThenInclude(c => c.Country)
                    .ThenInclude(r => r.Region)
                .Include(c => c.Stops)
                    .ThenInclude(l => l.Location);

            await listOfTripsWithGraph.ToListAsync();

            var listOfCountriesToReturn = new List<Country>();

            foreach (var trip in listOfTripsWithGraph)
            {
                var listOfCountries = trip.Stops
                    .Where(s => s.Location != null)
                    .Select(c => c.Location)
                    .Where(v => v.CountryId != null)
                    .Select(c => c.Country).Distinct().ToList();

                foreach (var country in listOfCountries)
                {
                    if (listOfCountriesToReturn.Where(c => c.Id == country.Id).Count() == 0)
                    {
                        listOfCountriesToReturn.Add(country);
                    }
                }
            }

            return listOfCountriesToReturn;
        }
    }
}

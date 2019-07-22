using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TWM.Data.Domain.GeoEntities;

namespace TWM.Data
{
    public class TripWMeStatsSeeder
    {
        private readonly TripWMeContext _context;
        public TripWMeStatsSeeder(TripWMeContext context)
        {
            _context = context;
        }

        public async Task SeedContinentStats()
        {
            foreach (var cont in _context.Continent.Include(cs => cs.Stats).ToList())
            {
                var countryCount = await GetTotlCountryNumberForContinentName(cont.Name);

                if (cont.Stats == null)
                {
                    var newStats = new ContinentStats() { CountryCount = countryCount, ContinentId = cont.Id };
                    cont.Stats = newStats;

                    await _context.SaveChangesAsync();
                }
                else if (cont.Stats.CountryCount != countryCount)
                {
                    cont.Stats.CountryCount = countryCount;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task SeedRegionStats()
        {
            foreach (var reg in _context.Region.Include(rs => rs.Stats).ToList())
            {
                var countryCount = await GetTotlCountryNumberForRegionName(reg.Name);

                if (reg.Stats == null)
                {
                    var newStats = new RegionStats() { CountryCount = countryCount, RegionId = reg.Id};
                    reg.Stats = newStats;

                    await _context.SaveChangesAsync();
                }
                else if (reg.Stats.CountryCount != countryCount)
                {
                    reg.Stats.CountryCount = countryCount;
                    await _context.SaveChangesAsync();
                }
            }
        }
        private async Task<int> GetTotlCountryNumberForContinentName(string continentName)
        {
            int countryCount = 0;

            var continent = await _context.Continent
                                                .Where(c => c.Name == continentName)
                                                .Include(r => r.Regions)
                                                .SingleOrDefaultAsync();

            foreach (var reg in continent.Regions)
            {
                countryCount += await GetTotlCountryNumberForRegionName(reg.Name);
            }
                                   
            return countryCount;
        }
        
        private async Task<int> GetTotlCountryNumberForRegionName(string regionName)
        {
            int countryCount = 0;
            countryCount = await _context.Region
                                    .Include(c => c.Countries)
                                    .Where(r => r.Name == regionName)
                                    .Select(t => t.Countries.Count)
                                    .FirstOrDefaultAsync();

            return countryCount;
        }
    }
}

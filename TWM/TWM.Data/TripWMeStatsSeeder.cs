using Microsoft.EntityFrameworkCore;
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

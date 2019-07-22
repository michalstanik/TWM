using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TWM.Data.Domain.GeoEntities;
using TWM.Data.RepositoryInterfaces;

namespace TWM.Data.Repository
{
    public class GeoAdminRepository : IGeoAdminRepository
    {
        private readonly TripWMeContext _context;
        private readonly ILogger<GeoAdminRepository> _logger;

        public GeoAdminRepository(TripWMeContext context, ILogger<GeoAdminRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ICollection<Continent>> GetContinents(bool includeRegions = false, bool includeCountries = false)
        {
            IQueryable<Continent> query = _context.Continent;

            if(includeRegions)
            {
                query = query.Include(t => t.Regions).ThenInclude(c => c.Stats);
            }

            if(includeCountries)
            {
                query = query.Include(t => t.Regions).ThenInclude(c => c.Countries);
            }

            return await query.ToListAsync();
        }
    }
}

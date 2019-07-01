using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWM.Data.Domain.GeoEntities;

namespace TWM.Data.RepositoryInterfaces
{
    public interface IGeoAdminRepository
    {
        Task<ICollection<Continent>> GetContinents(bool includeRegions, bool includeCountries);
    }
}

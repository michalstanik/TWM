using System.Collections.Generic;
using System.Threading.Tasks;
using TWM.Data.Domain.GeoEntities;
using TWM.Data.Domain.Users;

namespace TWM.Data.RepositoryInterfaces
{
    public interface IGeoEntitiesRepository
    {
        Task<ICollection<Country>> GetCountriesForTrip(int tripID);
        Task<ICollection<Country>> GetCountriesForAllTrips();
        Task<Dictionary<string, long>> GetCountireAssesmentForUser(string userId);

        Task<ICollection<Country>> GetCountiresWithAssesmentForUser(string userId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TWM.Data.Domain.Trips;

namespace TWM.Data.RepositoryInterfaces
{
    public interface ITripRepository
    {
        void Add<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<ICollection<Trip>> GetAllTripsAsync(bool includeStops = false, bool includeUsers = false);
    }
}

using Domain.Base;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<List<Location>> GetOriginAndDestinyLocationByName(string originName, string destinyName);
        Task AddAsync(Location location);

    }
}

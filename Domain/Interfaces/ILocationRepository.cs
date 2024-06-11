using Domain.Base;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        public Task<List<Location>> GetOriginAndDestinyLocationByName(string originName, string destinyName);
    }
}

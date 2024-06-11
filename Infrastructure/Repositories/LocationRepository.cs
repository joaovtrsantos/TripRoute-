using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LocationRepository(TripRouteContext tripRouteContext) : ILocationRepository
    {
        private readonly TripRouteContext _routeContext = tripRouteContext;
        public IUnitOfWork UnitOfWork => _routeContext;

        public async Task AddAsync(Location location)
        {
            await _routeContext.AddAsync(location);
            await _routeContext.SaveChangesAsync();
        }

        public async Task<Location> GetById(Guid id)
        {
            return await _routeContext.Location.SingleAsync(x => x.Id == id);
        }

        public async Task<List<Location>> GetOriginAndDestinyLocationByName(string originName, string destinyName)
        {
            return await _routeContext.Location.Where(x => x.Name == originName || x.Name == destinyName).ToListAsync();
        }
    }
}

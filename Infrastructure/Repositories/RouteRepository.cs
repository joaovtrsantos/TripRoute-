﻿using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RouteRepository(TripRouteContext tripRouteContext) : IRouteRepository
    {
        private readonly TripRouteContext _routeContext = tripRouteContext;
        public IUnitOfWork UnitOfWork => _routeContext;

        public async Task AddAsync(Route route)
        {
            await _routeContext.AddAsync(route);
            await _routeContext.SaveChangesAsync();
        }

        public async Task<List<Route>> GetAllAsync()
        {
            return await _routeContext.Route.ToListAsync();
        }
    }
}

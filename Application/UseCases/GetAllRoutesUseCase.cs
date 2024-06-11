using Application.Responses;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Application.UseCases
{
    public interface IGetAllRoutesUseCase
    {
        public Task<List<GetAllRoutesResponse>> GetAllRoutes();
    }

    public class GetAllRoutesUseCase(IRouteRepository routeRepository, ILocationRepository locationRepository) : IGetAllRoutesUseCase
    {
        private readonly IRouteRepository _routeRepository = routeRepository;
        private readonly ILocationRepository _locationRepository = locationRepository;

        public async Task<List<GetAllRoutesResponse>> GetAllRoutes()
        {
            var routes = await _routeRepository.GetAllAsync();

            var responseList = new List<GetAllRoutesResponse>();

            foreach (var route in routes)
            {
                var origin = await _locationRepository.GetById(route.OriginLocationId);
                var destiny = await _locationRepository.GetById(route.DestinyLocationId);

                var response = new GetAllRoutesResponse(origin.Name, destiny.Name, route.Cost);
                responseList.Add(response);
            }

            return responseList;
        }
    }
}

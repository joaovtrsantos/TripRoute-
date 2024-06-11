using Application.Requests;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public interface ICreateRouteUseCase
    {
        public Task CreateRoute(CreateRouteRequest createRouteRequest);
    }

    public class CreateRouteUseCase : ICreateRouteUseCase
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ILocationRepository _locationRepository;

        public CreateRouteUseCase(IRouteRepository routeRepository, ILocationRepository locationRepository)
        {
            _routeRepository = routeRepository;
            _locationRepository = locationRepository;
        }

        public async Task CreateRoute(CreateRouteRequest createRouteRequest)
        {
            var locations = await _locationRepository.GetOriginAndDestinyLocationByName(createRouteRequest.OriginLocationName, createRouteRequest.DestinyLocationName);
            var originLocation = locations.Where(x => x.Name == createRouteRequest.OriginLocationName).FirstOrDefault() ?? throw new Exception("No location found by Origin Name");
            var destinyLocation = locations.Where(x => x.Name == createRouteRequest.DestinyLocationName).FirstOrDefault() ?? throw new Exception("No location found by Origin Name");

            var route = new Route()
            {
                Cost = createRouteRequest.Cost,
                CreationDate = DateTime.Now,
                OriginLocation = originLocation,
                OriginLocationId = originLocation.Id,
                DestinyLocation = destinyLocation,
                DestinyLocationId = destinyLocation.Id
            };

            await _routeRepository.AddAsync(route);
        }
    }
}

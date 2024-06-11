using Application.Requests;
using Application.Services;
using Domain.Entities;
namespace Application.UseCases
{
    public interface ICalculateCheapestRouteUseCase
    {
        public Task<(List<string> Path, double Cost)> CalculateCheapestRoute(CalculateCheapestRouteRequest createLocationRequest);
    }

    public class CalculateCheapestRouteUseCase(IRouteFinderService routeFinderService) : ICalculateCheapestRouteUseCase
    {
        private readonly IRouteFinderService _routeFinderService = routeFinderService;

        public async Task<(List<string> Path, double Cost)> CalculateCheapestRoute(CalculateCheapestRouteRequest createLocationRequest)
        {
            var result = await _routeFinderService.FindCheapestRouteAsync(createLocationRequest.OriginLocationName, createLocationRequest.DestinyLocationName);
            return result;
        }
    }
}

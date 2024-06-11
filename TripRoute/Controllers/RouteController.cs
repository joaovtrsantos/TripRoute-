using Application.Requests;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace TripRoute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRoutes(IGetAllRoutesUseCase getAllRoutesUseCase)
        {
            var routes = await getAllRoutesUseCase.GetAllRoutes();
            return Ok(routes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoute(CreateRouteRequest createRouteRequest, ICreateRouteUseCase createRouteUseCase)
        {
            await createRouteUseCase.CreateRoute(createRouteRequest);
            return Ok();
        }

        [HttpGet("cheapest-route")]
        public async Task<IActionResult> GetCheapestRoute([FromQuery]CalculateCheapestRouteRequest calculateCheapestRouteRequest, ICalculateCheapestRouteUseCase calculateCheapestRouteUseCase)
        {
            var result = await calculateCheapestRouteUseCase.CalculateCheapestRoute(calculateCheapestRouteRequest);

            if (result.Path.Count == 0)
            {
                return NotFound("Route not found");
            }

            return Ok(new { Path = string.Join(" - ", result.Path), result.Cost });
        }
    }
}

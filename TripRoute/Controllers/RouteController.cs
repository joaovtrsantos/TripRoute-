using Application.Requests;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace TripRoute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        [HttpPost]
        public async Task<StatusCodeResult> CreateRoute(CreateRouteRequest createRouteRequest, ICreateRouteUseCase createRouteUseCase)
        {
            await createRouteUseCase.CreateRoute(createRouteRequest);
        }
    }
}

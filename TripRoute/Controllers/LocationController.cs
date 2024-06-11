using Application.Requests;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace TripRoute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        [HttpPost]
        public async Task<StatusCodeResult> CreateLocation(CreateLocationRequest createRouteRequest, ICreateLocationUseCase createLocationUseCase)
        {
            await createLocationUseCase.CreateLocation(createRouteRequest);
            return Ok();
        }
    }
}

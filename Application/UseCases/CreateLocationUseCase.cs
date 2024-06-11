using Application.Requests;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public interface ICreateLocationUseCase
    {
        public Task CreateLocation(CreateLocationRequest createLocationRequest);
    }

    public class CreateLocationUseCase(ILocationRepository locationRepository) : ICreateLocationUseCase
    {
        private readonly ILocationRepository _locationRepository = locationRepository;

        public async Task CreateLocation(CreateLocationRequest createLocationRequest)
        {
            var location = new Location()
            {
                CreationDate = DateTime.Now,
                Name = createLocationRequest.LocationName
            };

            await _locationRepository.AddAsync(location);
        }
    }
}

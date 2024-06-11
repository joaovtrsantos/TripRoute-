using Application.Services;
using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModule
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<ICreateRouteUseCase, CreateRouteUseCase>();
            services.AddScoped<ICreateLocationUseCase, CreateLocationUseCase>();
            services.AddScoped<IGetAllRoutesUseCase, GetAllRoutesUseCase>();
            services.AddScoped<ICalculateCheapestRouteUseCase, CalculateCheapestRouteUseCase>();

            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<IRouteFinderService, RouteFinderService>();
        }

    }
}

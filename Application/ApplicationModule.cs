using Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModule
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<ICreateRouteUseCase, CreateRouteUseCase>();
        }

    }
}

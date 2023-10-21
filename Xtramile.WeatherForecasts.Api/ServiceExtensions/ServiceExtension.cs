using Microsoft.Extensions.DependencyInjection;
using Xtramile.WeatherForecasts.Repository.Respositories;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Api.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder
                    .WithOrigins("*")
                    .AllowAnyMethod()
                    .Build());
            });
        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
        }
    }
}

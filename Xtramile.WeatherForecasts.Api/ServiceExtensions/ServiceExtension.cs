using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Xtramile.WeatherForecasts.Library.Mappers;
using Xtramile.WeatherForecasts.Repository.Repositories;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;
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
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
        }

        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient<IWeatherForecastRepository, WeatherForecastRepository>();
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WeatherForecastMapperConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

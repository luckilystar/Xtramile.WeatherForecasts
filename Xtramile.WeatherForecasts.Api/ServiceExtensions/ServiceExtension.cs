using Microsoft.Extensions.DependencyInjection;

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
    }
}

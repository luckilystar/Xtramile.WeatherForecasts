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

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IClientDao, ClientDao>();
        }
    }
}

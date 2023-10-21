using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Requests;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastService weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            this.weatherForecastService = weatherForecastService;
        }

        [HttpGet("{city}")]
        public async Task<GetWeatherForecastResponse> GetWeatherForecast(GetWeatherForecastRequest request)
        {
            return await weatherForecastService.GetWeatherForecast(request.City);
        }
    }
}

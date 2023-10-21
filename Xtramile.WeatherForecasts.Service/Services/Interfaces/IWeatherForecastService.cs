using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Responses;

namespace Xtramile.WeatherForecasts.Service.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<GetWeatherForecastResponse> GetWeatherForecast(string city);
    }
}

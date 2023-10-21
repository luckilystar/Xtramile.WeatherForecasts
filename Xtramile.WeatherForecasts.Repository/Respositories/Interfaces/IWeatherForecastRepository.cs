using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;

namespace Xtramile.WeatherForecasts.Repository.Repositories.Interfaces
{
    public interface IWeatherForecastRepository
    {
        Task<WeatherForecast> GetWeatherForecast(string city);
    }
}

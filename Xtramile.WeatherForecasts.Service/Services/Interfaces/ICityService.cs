using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Responses;

namespace Xtramile.WeatherForecasts.Service.Services.Interfaces
{
    public interface ICityService
    {
        Task<GetAllCitiesResponse> GetAllCities();
        Task<GetAllCitiesResponse> GetAllCities(string country);
    }
}

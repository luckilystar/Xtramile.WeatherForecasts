using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;

namespace Xtramile.WeatherForecasts.Repository.Respositories.Interfaces
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCities();
        Task<List<City>> GetAllCities(string country);
    }
}

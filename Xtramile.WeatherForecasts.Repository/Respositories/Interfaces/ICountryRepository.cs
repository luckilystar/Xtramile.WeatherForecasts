using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;

namespace Xtramile.WeatherForecasts.Repository.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();
    }
}

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Library.Utils;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;

namespace Xtramile.WeatherForecasts.Repository.Respositories
{
    public class CountryRepository : ICountryRepository
    {
        public async Task<List<Country>> GetAllCountries()
        {
            using StreamReader reader = new StreamReader(PathConst.COUNTRY_JSON_PATH);
            var json = await reader.ReadToEndAsync();
            var jarray = JArray.Parse(json);
            List<Country> countries = new List<Country>();
            foreach (var item in jarray)
            {
                Country country = item.ToObject<Country>();
                countries.Add(country);
            }
            return countries;
        }
    }
}

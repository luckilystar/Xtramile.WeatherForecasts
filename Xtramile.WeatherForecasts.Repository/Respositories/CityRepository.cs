using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Library.Utils;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;

namespace Xtramile.WeatherForecasts.Repository.Respositories
{
    public class CityRepository : ICityRepository
    {
        public async Task<List<City>> GetAllCities()
        {
            try
            {
                var result = await OpenAndReadCityFile();
                List<City> cities = ParseCityData(result);
                return cities;
            }
            catch (Exception)
            {
                return new List<City>();
            }
        }

        public async Task<List<City>> GetAllCities(string country)
        {
            var cities = await GetAllCities();
            return cities.Where(c => c.Country.ToLower().Contains(country.Trim().ToLower())).ToList();
        }

        private async Task<JArray> OpenAndReadCityFile()
        {
            using StreamReader reader = new StreamReader(PathConst.CITY_JSON_PATH);
            var json = await reader.ReadToEndAsync();
            var jarray = JArray.Parse(json);
            return jarray;
        }

        private List<City> ParseCityData(JArray jarray)
        {
            List<City> cities = new List<City>();
            foreach (var item in jarray)
            {
                City city = item.ToObject<City>();
                cities.Add(city);
            }
            return cities;
        }
    }
}

using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Library.Utils;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;
using Newtonsoft.Json;

namespace Xtramile.WeatherForecasts.Repository.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly HttpClient client;
        public WeatherForecastRepository(HttpClient client)
        {
            this.client = client;
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<WeatherForecast> GetWeatherForecast(string city)
        {
            try
            {
                if (string.IsNullOrEmpty(city))
                    throw new Exception("City cannot be empty to retrieve weather forecast.");

                var apiUrl = ApiConst.GET_WEATHER_FORECAST + "&q=" + city;

                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherForecast>(result);
                }
                else
                    return new WeatherForecast();
            }
            catch (Exception)
            {
                throw new Exception("There is a problem to retrieve weather forecast.");
            }
        }
    }
}

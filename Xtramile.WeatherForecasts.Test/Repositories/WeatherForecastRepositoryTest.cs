using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Repository.Repositories;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Repositories
{
    [TestFixture]
    public class WeatherForecastRepositoryTest
    {
        private IWeatherForecastRepository weatherForecastRepository;
        private HttpClient httpClient;

        [SetUp]
        public void Setup()
        {
            httpClient = new HttpClient();
            weatherForecastRepository = new WeatherForecastRepository(httpClient);
        }

        [Test]
        public async Task GetWeather_Should_NotNull()
        {
            string city = "London";
            var result = await weatherForecastRepository.GetWeatherForecast(city);
            Assert.IsNotNull(result.Main.Temp);
        }
    }
}
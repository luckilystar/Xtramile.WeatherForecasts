using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Repositories
{
    [TestFixture]
    public class WeatherForecastRepositoryTest
    {
        private Mock<IWeatherForecastRepository> _weatherForecastRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _weatherForecastRepositoryMock = new Mock<IWeatherForecastRepository>();
        }

        [Test]
        public async Task GetWeather_Should_NotNull()
        {
            string city = "London";
            WeatherForecast weatherForecast = new WeatherForecast();

            _weatherForecastRepositoryMock.Setup(w => w.GetWeatherForecast(It.IsAny<string>())).Returns(Task.FromResult(weatherForecast));
            var result = await _weatherForecastRepositoryMock.Object.GetWeatherForecast(city);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetWeatherForecast_CityCannotBeNulled_Should_Return_Exception()
        {
            string city = string.Empty;

            _weatherForecastRepositoryMock.Setup(w => w.GetWeatherForecast(It.IsAny<string>())).Throws(new Exception("City cannot be empty to retrieve weather forecast."));
            var ex = Assert.ThrowsAsync(Is.TypeOf<Exception>(), async () => await _weatherForecastRepositoryMock.Object.GetWeatherForecast(city));

            Assert.That(ex.Message, Is.EqualTo("City cannot be empty to retrieve weather forecast."));
        }
    }
}
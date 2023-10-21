using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Services
{
    [TestFixture]
    public class WeatherForecastServiceTest
    {
        private IWeatherForecastService _weatherForecastService;
        private Mock<IWeatherForecastRepository> _weatherForecastRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _weatherForecastRepositoryMock = new Mock<IWeatherForecastRepository>();
            _weatherForecastService = new WeatherForecastService(_weatherForecastRepositoryMock.Object);
        }

        [Test]
        public async Task GetWeatherForecast_Should_Return_Temperature()
        {
            string city = "London";
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.Main = new WeatherValue
            {
                Temp = 100
            };
            _weatherForecastRepositoryMock.Setup(w => w.GetWeatherForecast(It.IsAny<string>())).Returns(Task.FromResult(weatherForecast));
            var result = await _weatherForecastService.GetWeatherForecast(city);
            Assert.AreEqual(result.Data.TemperatureF, 212);
        }

        [Test]
        public async Task GetWeatherForecast_CityCannotBeNulled_Should_Return_Exception()
        {
            string city = string.Empty;

            _weatherForecastRepositoryMock.Setup(w => w.GetWeatherForecast(It.IsAny<string>())).Throws(new Exception("City cannot be empty to retrieve weather forecast."));
            var result = await _weatherForecastService.GetWeatherForecast(city);
            Assert.NotNull(result);
        }
    }
}
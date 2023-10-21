using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Controllers;
using Xtramile.WeatherForecasts.Library.Dtos;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Library.Requests;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Service.Services;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Controllers
{
    [TestFixture]
    public class WeatherForecastControllerTest
    {
        private WeatherForecastController _weatherForecastController;
        private Mock<IWeatherForecastService> _weatherForecastServiceMock;

        [SetUp]
        public void Setup()
        {
            _weatherForecastServiceMock = new Mock<IWeatherForecastService>();
            _weatherForecastController = new WeatherForecastController(_weatherForecastServiceMock.Object);
        }


        [Test]
        public async Task GetWeatherForecast_Should_Return_Temperature()
        {
            string city = "London";

            var request = new GetWeatherForecastRequest { City = "London" };

            WeatherForecastDto weatherForecast = new WeatherForecastDto();
            weatherForecast.TemperatureC = 100;
            var response = new GetWeatherForecastResponse(weatherForecast);

            _weatherForecastServiceMock.Setup(w => w.GetWeatherForecast(It.IsAny<string>())).Returns(Task.FromResult(response));
            var result = await _weatherForecastController.GetWeatherForecast(request);
            Assert.AreEqual(result.Data.TemperatureF, 212);
        }

        [Test]
        public void GetWeatherForecast_CityCannotBeNulled_Should_Return_Exception()
        {
            var request = new GetWeatherForecastRequest { City = string.Empty };

            _weatherForecastServiceMock.Setup(w => w.GetWeatherForecast(It.IsAny<string>())).Throws(new Exception("City cannot be empty to retrieve weather forecast."));
            var ex = Assert.ThrowsAsync(Is.TypeOf<Exception>(), async () => await _weatherForecastController.GetWeatherForecast(request));

            Assert.That(ex.Message, Is.EqualTo("City cannot be empty to retrieve weather forecast."));
        }
    }
}
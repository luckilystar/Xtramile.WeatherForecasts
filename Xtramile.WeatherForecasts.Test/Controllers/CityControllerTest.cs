using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Controllers;
using Xtramile.WeatherForecasts.Library.Dtos;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Library.Requests;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Controllers
{
    [TestFixture]
    public class CityControllerTest
    {
        private CityController _cityController;
        private Mock<ICityService> _cityServiceMock;

        [SetUp]
        public void Setup()
        {
            _cityServiceMock = new Mock<ICityService>();
            _cityController = new CityController(_cityServiceMock.Object);
        }

        [Test]
        public async Task GetAllCities_Should_MoreThanZero()
        {
            var cities = new List<CityDto>{
                new CityDto{ },
                new CityDto{ }
            };
            var response = new GetAllCitiesResponse(cities);
            _cityServiceMock.Setup(c => c.GetAllCities()).Returns(Task.FromResult(response));
            var result = await _cityController.GetAllCities();
            Assert.Greater(result.Data.Count, 0);
        }


        [Test]
        public async Task GetAllCitiesByCountry_Should_MoreThanZero()
        {
            string country = "GB";
            var cities = new List<CityDto>{
                new CityDto{ },
                new CityDto{ }
            };
            var response = new GetAllCitiesResponse(cities);
            _cityServiceMock.Setup(c => c.GetAllCities(It.IsAny<string>())).Returns(Task.FromResult(response));
            GetAllCitiesByCountryRequest request = new GetAllCitiesByCountryRequest
            {
                Country = country
            };
            var result = await _cityController.GetAllCitiesByCountry(request);
            Assert.Greater(result.Data.Count, 0);
        }
    }
}
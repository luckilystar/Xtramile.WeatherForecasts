using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Repositories
{
    [TestFixture]
    public class CityRepositoryTest
    {
        private Mock<ICityRepository> _cityRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _cityRepositoryMock = new Mock<ICityRepository>();
        }

        [Test]
        public async Task GetAllCities_Should_MoreThanZero()
        {
            var cities = new List<City>{
                new City{ },
                new City{ }
            };
            _cityRepositoryMock.Setup(c => c.GetAllCities()).Returns(Task.FromResult(cities));
            var result = await _cityRepositoryMock.Object.GetAllCities();
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public async Task GetAllCitiesByCountry_Should_MoreThanZero()
        {
            string country = "GB";
            var cities = new List<City>{
                new City{ },
                new City{ }
            };
            _cityRepositoryMock.Setup(c => c.GetAllCities(It.IsAny<string>())).Returns(Task.FromResult(cities));
            var result = await _cityRepositoryMock.Object.GetAllCities(country);
            Assert.Greater(result.Count, 0);
        }
    }
}
using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Mappers;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Services
{
    [TestFixture]
    public class CityServiceTest
    {
        private ICityService _cityService;
        private Mock<ICityRepository> _cityRepositoryMock;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _cityRepositoryMock = new Mock<ICityRepository>();

            var profile = new WeatherForecastMapperConfig();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(profile)));
            _cityService = new CityService(_mapper, _cityRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllCities_Should_MoreThanZero()
        {
            var cities = new List<City>{
                new City{ },
                new City{ }
            };
            _cityRepositoryMock.Setup(c => c.GetAllCities()).Returns(Task.FromResult(cities));
            var result = await _cityService.GetAllCities();
            Assert.Greater(result.Data.Count, 0);
        }


        [Test]
        public async Task GetAllCitiesByCountry_Should_MoreThanZero()
        {
            var cities = new List<City>{
                new City{ },
                new City{ }
            };
            _cityRepositoryMock.Setup(c => c.GetAllCities(It.IsAny<string>())).Returns(Task.FromResult(cities));
            string country = "GB";
            var result = await _cityService.GetAllCities(country);
            Assert.Greater(result.Data.Count, 0);
        }
    }
}
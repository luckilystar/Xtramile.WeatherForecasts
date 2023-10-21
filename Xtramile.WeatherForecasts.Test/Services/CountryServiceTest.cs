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
    public class CountryServiceTest
    {
        private Mock<ICountryRepository> _countryRepositoryMock;
        private ICountryService _countryService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _countryRepositoryMock = new Mock<ICountryRepository>();

            var profile = new WeatherForecastMapperConfig();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(profile)));
            _countryService = new CountryService(_mapper,_countryRepositoryMock.Object);

        }

        [Test]
        public async Task GetAllCountries_Should_MoreThanZero()
        {
            var countries = new List<Country>{
                new Country{ },
                new Country{ }
            };
            _countryRepositoryMock.Setup(c => c.GetAllCountries()).Returns(Task.FromResult(countries));

            var result = await _countryService.GetAllCountries();
            Assert.Greater(result.Data.Count, 0);
        }
    }
}
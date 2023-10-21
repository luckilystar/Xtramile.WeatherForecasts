using AutoMapper;
using NUnit.Framework;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Mappers;
using Xtramile.WeatherForecasts.Repository.Respositories;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Services
{
    [TestFixture]
    public class CityServiceTest
    {
        private ICityService _cityService;
        private ICityRepository _cityRepository;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _cityRepository = new CityRepository();

            var profile = new WeatherForecastMapperConfig();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(profile)));
            _cityService = new CityService(_mapper, _cityRepository);
        }

        [Test]
        public async Task GetAllCities_Should_MoreThanZero()
        {
            var result = await _cityService.GetAllCities();
            Assert.Greater(result.Data.Count, 0);
        }


        [Test]
        public async Task GetAllCitiesByCountry_Should_MoreThanZero()
        {
            string country = "GB";
            var result = await _cityService.GetAllCities(country);
            Assert.Greater(result.Data.Count, 0);
        }
    }
}
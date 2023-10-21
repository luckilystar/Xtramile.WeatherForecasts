using AutoMapper;
using NUnit.Framework;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Controllers;
using Xtramile.WeatherForecasts.Library.Mappers;
using Xtramile.WeatherForecasts.Repository.Repositories;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Controllers
{
    [TestFixture]
    public class CountryControllerTest
    {
        private CountryController _countryController;
        private ICountryRepository _countryRepository;
        private ICountryService _countryService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _countryRepository = new CountryRepository();

            var profile = new WeatherForecastMapperConfig();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(profile)));
            _countryService = new CountryService(_mapper, _countryRepository);

            _countryController = new CountryController(_countryService);
        }

        [Test]
        public async Task GetAllCountries_Should_MoreThanZero()
        {
            var result = await _countryController.GetAllCountries();
            Assert.Greater(result.Data.Count, 0);
        }
    }
}
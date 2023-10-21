using AutoMapper;
using NUnit.Framework;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Mappers;
using Xtramile.WeatherForecasts.Repository.Respositories;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Repositories
{
    [TestFixture]
    public class CountryServiceTest
    {
        private ICountryService _countryService;
        private ICountryRepository _countryRepository;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _countryRepository = new CountryRepository();

            var profile = new WeatherForecastMapperConfig();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(profile)));
            _countryService = new CountryService(_mapper, _countryRepository);
        }

        [Test]
        public async Task GetAllCountries_Should_MoreThanZero()
        {
            var result = await _countryService.GetAllCountries();
            Assert.Greater(result.Data.Count, 0);
        }
    }
}
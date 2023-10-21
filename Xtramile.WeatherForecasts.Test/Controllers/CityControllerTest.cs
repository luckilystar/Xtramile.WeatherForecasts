using AutoMapper;
using NUnit.Framework;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Controllers;
using Xtramile.WeatherForecasts.Library.Mappers;
using Xtramile.WeatherForecasts.Library.Requests;
using Xtramile.WeatherForecasts.Repository.Respositories;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Controllers
{
    [TestFixture]
    public class CityControllerTest
    {
        private CityController _cityController;
        private ICityRepository _cityRepository;
        private ICityService _cityService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _cityRepository = new CityRepository();

            var profile = new WeatherForecastMapperConfig();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(profile)));
            _cityService = new CityService(_mapper, _cityRepository);

            _cityController = new CityController(_cityService);
        }

        [Test]
        public async Task GetAllCities_Should_MoreThanZero()
        {
            var result = await _cityController.GetAllCities();
            Assert.Greater(result.Data.Count, 0);
        }


        [Test]
        public async Task GetAllCitiesByCountry_Should_MoreThanZero()
        {
            string country = "GB";
            GetAllCitiesByCountryRequest request = new GetAllCitiesByCountryRequest
            {
                Country = country
            };
            var result = await _cityController.GetAllCitiesByCountry(request);
            Assert.Greater(result.Data.Count, 0);
        }
    }
}
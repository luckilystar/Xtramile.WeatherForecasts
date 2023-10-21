using NUnit.Framework;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Repository.Respositories;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Repositories
{
    [TestFixture]
    public class CityRepositoryTest
    {
        private ICityRepository _cityRepository;

        [SetUp]
        public void Setup()
        {
            _cityRepository = new CityRepository();
        }

        [Test]
        public async Task GetAllCities_Should_MoreThanZero()
        {
            var result = await _cityRepository.GetAllCities();
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public async Task GetAllCitiesByCountry_Should_MoreThanZero()
        {
            string country = "GB";
            var result = await _cityRepository.GetAllCities(country);
            Assert.Greater(result.Count, 0);
        }
    }
}
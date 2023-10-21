using NUnit.Framework;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Repository.Respositories;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Repositories
{
    [TestFixture]
    public class CountryRepositoryTest
    {
        private ICountryRepository _countryRepository;

        [SetUp]
        public void Setup()
        {
            _countryRepository = new CountryRepository();
        }

        [Test]
        public async Task GetAllCountries_Should_MoreThanZero()
        {
            var result = await _countryRepository.GetAllCountries();
            Assert.Greater(result.Count, 0);
        }
    }
}
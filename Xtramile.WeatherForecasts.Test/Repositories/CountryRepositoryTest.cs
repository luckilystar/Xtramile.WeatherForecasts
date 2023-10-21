using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Models;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Repositories
{
    [TestFixture]
    public class CountryRepositoryTest
    {
        private Mock<ICountryRepository> _countryRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _countryRepositoryMock = new Mock<ICountryRepository>();
        }

        [Test]
        public async Task GetAllCountries_Should_MoreThanZero()
        {
            var countries = new List<Country>{
                new Country{ },
                new Country{ }
            };
            _countryRepositoryMock.Setup(c => c.GetAllCountries()).Returns(Task.FromResult(countries));
            var result = await _countryRepositoryMock.Object.GetAllCountries();
            Assert.Greater(result.Count, 0);
        }
    }
}
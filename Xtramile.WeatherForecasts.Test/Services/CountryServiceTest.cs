using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Dtos;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Test.Services
{
    [TestFixture]
    public class CountryServiceTest
    {
        private Mock<ICountryService> _countryServiceMock;

        [SetUp]
        public void Setup()
        {
            _countryServiceMock = new Mock<ICountryService>();
        }

        [Test]
        public async Task GetAllCountries_Should_MoreThanZero()
        {
            var countries = new List<CountryDto>{
                new CountryDto{ },
                new CountryDto{ }
            };
            var response = new GetAllCountriesResponse(countries);
            _countryServiceMock.Setup(c => c.GetAllCountries()).Returns(Task.FromResult(response));

            var result = await _countryServiceMock.Object.GetAllCountries();
            Assert.Greater(result.Data.Count, 0);
        }
    }
}
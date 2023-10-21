using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<GetAllCountriesResponse> GetAllCountries()
        {
            return await countryService.GetAllCountries();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Requests;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<GetAllCitiesResponse> GetAllCities()
        {
            return await cityService.GetAllCities();
        }


        [HttpGet("GetCityByCountry")]
        public async Task<GetAllCitiesResponse> GetAllCitiesByCountry([FromQuery] GetAllCitiesByCountryRequest request)
        {
            return await cityService.GetAllCities(request.Country);
        }
    }
}

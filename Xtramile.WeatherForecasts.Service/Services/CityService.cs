using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Dtos;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Service.Services
{
    public class CityService : ICityService
    {
        private readonly IMapper mapper;
        private readonly ICityRepository cityRepository;

        public CityService(IMapper mapper,
            ICityRepository cityRepository)
        {
            this.mapper = mapper;
            this.cityRepository = cityRepository;
        }

        public async Task<GetAllCitiesResponse> GetAllCities()
        {
            var result = await cityRepository.GetAllCities();
            return new GetAllCitiesResponse(mapper.Map<List<CityDto>>(result));
        }

        public async Task<GetAllCitiesResponse> GetAllCities(string country)
        {
            var result = await cityRepository.GetAllCities(country);
            return new GetAllCitiesResponse(mapper.Map<List<CityDto>>(result));
        }
    }
}

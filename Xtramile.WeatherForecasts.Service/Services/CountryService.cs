using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Dtos;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Repository.Respositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper mapper;
        private readonly ICountryRepository countryRepository;

        public CountryService(IMapper mapper,
            ICountryRepository countryRepository)
        {
            this.mapper = mapper;
            this.countryRepository = countryRepository;
        }
        public async Task<GetAllCountriesResponse> GetAllCountries()
        {
            var result = await countryRepository.GetAllCountries();
            return new GetAllCountriesResponse(mapper.Map<List<CountryDto>>(result));
        }
    }
}

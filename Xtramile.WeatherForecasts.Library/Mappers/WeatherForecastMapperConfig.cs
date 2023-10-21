using AutoMapper;
using Xtramile.WeatherForecasts.Library.Dtos;
using Xtramile.WeatherForecasts.Library.Models;

namespace Xtramile.WeatherForecasts.Library.Mappers
{
    public class WeatherForecastMapperConfig : Profile
    {
        public WeatherForecastMapperConfig()
        {
            CreateMap<CityDto, City>();
            CreateMap<CountryDto, Country>();

            CreateMap<City, CityDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}

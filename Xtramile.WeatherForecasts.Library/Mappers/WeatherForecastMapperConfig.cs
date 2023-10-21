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
            CreateMap<WeatherForecastDto, WeatherForecast>();
            CreateMap<WeatherDto, Weather>();
            CreateMap<WindDto, Wind>();

            CreateMap<City, CityDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<WeatherForecast, WeatherForecastDto>();
            CreateMap<Weather, WeatherDto>();
            CreateMap<Wind, WindDto>();
        }
    }
}

﻿using System;
using System.Threading.Tasks;
using Xtramile.WeatherForecasts.Library.Dtos;
using Xtramile.WeatherForecasts.Library.Responses;
using Xtramile.WeatherForecasts.Repository.Repositories.Interfaces;
using Xtramile.WeatherForecasts.Service.Services.Interfaces;

namespace Xtramile.WeatherForecasts.Service.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            this.weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<GetWeatherForecastResponse> GetWeatherForecast(string city)
        {
            try
            {
                var result = await weatherForecastRepository.GetWeatherForecast(city);
                return new GetWeatherForecastResponse(new WeatherForecastDto(result));
            }
            catch (Exception ex)
            {
                return new GetWeatherForecastResponse(ex.Message);
            }
        }
    }
}

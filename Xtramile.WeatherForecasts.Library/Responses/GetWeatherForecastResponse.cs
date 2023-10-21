using System.Collections.Generic;
using Xtramile.WeatherForecasts.Library.Dtos;

namespace Xtramile.WeatherForecasts.Library.Responses
{
    public class GetWeatherForecastResponse: BaseResponse<WeatherForecastDto>
    {
        public GetWeatherForecastResponse(WeatherForecastDto weatherForecast):base(weatherForecast) { }
    }
}

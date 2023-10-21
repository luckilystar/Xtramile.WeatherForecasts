using System.Collections.Generic;
using System.Linq;
using Xtramile.WeatherForecasts.Library.Models;

namespace Xtramile.WeatherForecasts.Library.Dtos
{
    public class WeatherForecastDto
    {
        public WeatherForecastDto() { }
        public WeatherForecastDto(WeatherForecast w)
        {
            Pressure = w.Main.Pressure;
            Humidity = w.Main.Humidity;
            Visibility = w.Visibility;
            Wind = new WindDto(w.Wind);
            Weather = w.Weather.Select(w => new WeatherDto(w)).ToList();
            TemperatureC = w.Main.Temp;
            Latitude = w.Coord.Lat;
            Longitude = w.Coord.Lon;
            TimeZone = w.TimeZone;
        }
        public int TimeZone { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public int Visibility { get; set; }

        public WindDto Wind { get; set; }

        public List<WeatherDto> Weather { get; set; }

        public float TemperatureC { get; set; }

        public float TemperatureF => 32 + (float)(TemperatureC * 9 / 5);
    }
}

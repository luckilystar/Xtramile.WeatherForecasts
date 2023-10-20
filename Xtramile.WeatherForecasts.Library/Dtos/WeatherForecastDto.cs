using Xtramile.WeatherForecasts.Library.Models;

namespace Xtramile.WeatherForecasts.Library.Dtos
{
    public class WeatherForecastDto
    {
        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public int Visibility { get; set; }

        public WindDto Wind { get; set; }

        public WeatherDto Weather { get; set; }

        public float TemperatureC { get; set; }

        public float TemperatureF => 32 + (float)(TemperatureC / 0.5556);
    }
}

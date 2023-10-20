namespace Xtramile.WeatherForecasts.Library.Models
{
    public class WeatherForecast
    {
        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public int Visibility { get; set; }

        public Wind Wind { get; set; }

        public Weather Weather { get; set; }

        public float TemperatureC { get; set; }

        public float TemperatureF => 32 + (float)(TemperatureC / 0.5556);
    }
}

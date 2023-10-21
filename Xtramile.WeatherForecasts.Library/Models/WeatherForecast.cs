namespace Xtramile.WeatherForecasts.Library.Models
{
    public class WeatherForecast
    {
        public int Visibility { get; set; }
        public int TimeZone { get; set; }
        public Coordination Coord { get; set; }
        public Wind Wind { get; set; }
        public Weather[] Weather { get; set; }
        public WeatherValue Main { get; set; }
    }
}

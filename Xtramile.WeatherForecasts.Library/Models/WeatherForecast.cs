using System.Collections.Generic;

namespace Xtramile.WeatherForecasts.Library.Models
{
    public class WeatherForecast
    {
        public WeatherForecast()
        {
            Coord = new Coordination();
            Wind = new Wind();
            Main = new WeatherValue();
            Weather = new List<Weather>().ToArray();
        }
        public int Visibility { get; set; }
        public int TimeZone { get; set; }
        public Coordination Coord { get; set; }
        public Wind Wind { get; set; }
        public Weather[] Weather { get; set; }
        public WeatherValue Main { get; set; }
    }
}

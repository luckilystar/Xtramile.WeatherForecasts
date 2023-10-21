using Xtramile.WeatherForecasts.Library.Models;

namespace Xtramile.WeatherForecasts.Library.Dtos
{
    public class WeatherDto
    {
        public WeatherDto(Weather weather)
        {
            Main = weather.Main;
            Description = weather.Description;
            Icon = weather.Icon;
        }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}

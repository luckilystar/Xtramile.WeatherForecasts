using System.Text.Json.Serialization;
using Xtramile.WeatherForecasts.Library.Dtos;

namespace Xtramile.WeatherForecasts.Library.Models
{
    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}

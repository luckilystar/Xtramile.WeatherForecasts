using Xtramile.WeatherForecasts.Library.Models;

namespace Xtramile.WeatherForecasts.Library.Dtos
{
    public class WindDto
    {
        public WindDto(Wind wind)
        {
            Speed = wind.Speed;
            Degree = wind.Deg;
        }
        public float Speed { get; set; }
        public int Degree { get; set; }
    }
}

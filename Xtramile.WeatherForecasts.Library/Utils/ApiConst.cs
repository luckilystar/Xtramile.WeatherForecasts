namespace Xtramile.WeatherForecasts.Library.Utils
{
    public static class ApiConst
    {
        private const string GetWeatherForecastUrl = "https://api.openweathermap.org/data/2.5/weather?appid=";

        private const string WeatherForecastApiKey = "35ec8c24ccbea0c46c06a7e16bc76ea6";
        public static string GET_WEATHER_FORECAST { get { return GetWeatherForecastUrl + WeatherForecastApiKey; } }
    }
}

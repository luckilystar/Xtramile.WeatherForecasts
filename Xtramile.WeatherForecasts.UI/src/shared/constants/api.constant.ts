export class APICONST {
  private static URL: string = "http://localhost:3461/";

  public static COUNTRY_URL = {
    GET_COUNTRY: this.URL + "country"
  };

  public static CITY_URL = {
    GET_CITY_BY_COUNTRY: this.URL + "city/getCityByCountry"
  };

  public static WEATHER_FORECAST_URL = {
    GET_WEATHER_FORECAST: this.URL +"weatherForecast"
  };
}

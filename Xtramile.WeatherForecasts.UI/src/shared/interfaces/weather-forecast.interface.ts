import { Weather } from "./weather.interface";
import { Wind } from "./wind-interface";

export interface WeatherForecast {
  timezone: number;
  latitude: number;
  longitude: number;
  pressure: number;
  humidity: number;
  visibility: number;
  wind: Wind;
  weather: Weather[];
  temperatureC: number;
  temperatureF: number;
}

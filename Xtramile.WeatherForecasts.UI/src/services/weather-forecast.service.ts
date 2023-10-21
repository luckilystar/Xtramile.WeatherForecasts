import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APICONST } from '../shared/constants/api.constant';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WeatherForecastService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  getWeatherForecast(city: string): Observable<any> {
    return this.http.get(APICONST.WEATHER_FORECAST_URL.GET_WEATHER_FORECAST + "?city=" + city);
  }
}

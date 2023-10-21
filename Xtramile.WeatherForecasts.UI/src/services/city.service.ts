import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APICONST } from '../shared/constants/api.constant';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class CityService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  getCitiesByCountry(country: string): Observable<any> {
    return this.http.get(APICONST.CITY_URL.GET_CITY_BY_COUNTRY + "?country=" + country);
  }
}

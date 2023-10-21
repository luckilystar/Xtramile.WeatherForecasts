import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APICONST } from '../shared/constants/api.constant';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  getAllCountries(): Observable<any>{
    return this.http.get(APICONST.COUNTRY_URL.GET_COUNTRY);
  }
}

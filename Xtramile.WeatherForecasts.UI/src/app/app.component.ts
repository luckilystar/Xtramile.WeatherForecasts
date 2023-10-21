import { Component, Output } from '@angular/core';
import { CityService } from '../services/city.service';
import { CountryService } from '../services/country.service';
import { WeatherForecastService } from '../services/weather-forecast.service';
import { City } from '../shared/interfaces/city.service';
import { Country } from '../shared/interfaces/country.interface';
import { WeatherForecast } from '../shared/interfaces/weather-forecast.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public forecasts?: WeatherForecast[];
  @Output() countries?: Country[];
  @Output() cities?: City[];
  @Output() weatherForecast?: WeatherForecast;
  countryCode: string = "";
  cityName: string = "";
  private countryService: CountryService;
  private cityService: CityService;
  private weatherForecastService: WeatherForecastService;

  constructor(
    countryService: CountryService,
    cityService: CityService,
    weatherForecastService: WeatherForecastService
  ) {
    this.countryService = countryService;
    this.cityService = cityService;
    this.weatherForecastService = weatherForecastService;
    this.getAllCountries();
  }

  getAllCountries() {
    this.countryService.getAllCountries().subscribe(result => {
      if (result.success) {
        this.countries = result.data;
      }
    }, error => console.error(error));
  }

  getAllCitiesByCountries() {
    if (this.countryCode != null && this.countryCode!="") {
      this.cityService.getCitiesByCountry(this.countryCode).subscribe(result => {
        if (result.success) {
          this.cities = result.data;
        }
      }, error => console.error(error));
    }
  }

  getWeatherForecast() {
    if (this.cityName != null && this.cityName != "") {
      this.weatherForecastService.getWeatherForecast(this.cityName).subscribe(result => {
        if (result.success) {
          this.weatherForecast = result.data;
          console.log(result.data);
        }
      }, error => console.error(error));
    }
  }

  title = 'Weather Forecast';
}


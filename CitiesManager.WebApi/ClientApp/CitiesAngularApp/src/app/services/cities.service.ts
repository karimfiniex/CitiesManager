import { Injectable } from '@angular/core';
import { City } from "../models/city";
import { HttpClient } from "@angular/common/http";
import { Observable, observable } from "rxjs";
@Injectable({
  providedIn: 'root'
})
export class CitiesService {
  cities: City[] = [];

  constructor(private httpClient: HttpClient) {
  }

  public getCities(): Observable<City[]> {
    return this.httpClient.get<City[]>("https://localhost:7234/api/cities");
  }
}

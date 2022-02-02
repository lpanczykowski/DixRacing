import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Driver } from '_models/driver';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer '+ JSON.parse(localStorage.getItem('user'))?.token
  })
}

@Injectable({
  providedIn: 'root'
})
export class DriverService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDrivers() {
    return this.http.get<Driver>(this.baseUrl + 'event/1/participants', httpOptions);
  }

  //getDriver(userId:number){
  //  return this.http.get<Driver>(this.baseUrl+'event/1/participants/'+ userId, httpOptions);
  //}
}

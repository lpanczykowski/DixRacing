import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Driver } from '../_models/driver/driver';
import { DriverParams } from '../_models/driver/driverParams';
import { PaginatedResult } from '../_models/pagination';
import { getPaginationHeaders } from './paginationHelper';


@Injectable({
  providedIn: 'root'
})
export class DriverService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getPaginatedDrivers(driverParams : DriverParams) {
    let params = getPaginationHeaders(driverParams.pageNumber,driverParams.pageSize);
    return this.http.get<PaginatedResult<Driver>>(this.baseUrl + 'event/1/participants', {params :params});
  }

  getDrivers(eventId:number) {
    return this.http.get<Driver[]>(this.baseUrl + 'event/' + eventId + '/participants');
  }

  //getDriver(userId:number){
  //  return this.http.get<Driver>(this.baseUrl+'event/1/participants/'+ userId, httpOptions);
  //}
}

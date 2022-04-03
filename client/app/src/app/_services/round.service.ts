import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
  export class RoundService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }
    //TODO: Wywalić do event service
    getRounds() {
      return this.http.get(this.baseUrl + 'event/1/rounds');
    }
}

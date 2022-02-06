import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Round } from '_models/round';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer '+ JSON.parse(localStorage.getItem('user'))?.token
  })
}

@Injectable({
  providedIn: 'root'
})
  export class RoundService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getRounds() {
      return this.http.get<Round[]>(this.baseUrl + 'event/1/rounds', httpOptions);
    }
}

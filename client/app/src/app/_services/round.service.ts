import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RaceCreateDto } from 'app/_models/raceCreateDto';
import { environment } from 'environments/environment';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json-patch+json'})
};

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

    createRace(eventId:number,raceCreateDto:RaceCreateDto){
      return this.http.post(this.baseUrl+'/'+eventId,JSON.stringify(raceCreateDto),httpOptions);
    }
}

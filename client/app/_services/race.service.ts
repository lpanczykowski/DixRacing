import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Race } from '_models/race';

@Injectable({
  providedIn: 'root'
})
export class RaceService {
baseUrl=environment.apiUrl;
  constructor(private http: HttpClient) { }

  getRaces(roundId:number)
  {
    return this.http.get<Race[]>(this.baseUrl + 'round/' + roundId + '/races')
  }
}

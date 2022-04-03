import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Race } from '../_models/race';
import { RaceResult } from '../_models/raceResult';

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
 //TODO: controller na get race, quali, preq results
  getRaceResults(raceId:number, resultsSelector:string)
  {
    return this.http.get<RaceResult[]>(this.baseUrl + 'race/' + raceId + '/' + resultsSelector + '/results')
  }


}

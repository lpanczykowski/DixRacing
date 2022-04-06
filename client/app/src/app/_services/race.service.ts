import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserStatusDto } from 'app/_models/userStatusDto';
import { environment } from 'environments/environment';
import { Race } from '../_models/race';
import { RaceResult } from '../_models/raceResult';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json-patch+json'})
};

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

  changeRaceStatus(userStatusDto:any)
  {
    return this.http.post<UserStatusDto[]>(this.baseUrl+'race/racestatus/change',JSON.stringify({userStatusDto}),httpOptions)
  }

  checkUserStatus(raceId:number,userId:number)
  {
    return this.http.get<UserStatusDto[]>(this.baseUrl+'race/'+raceId+'/'+userId+'/racestatus')
  }
}

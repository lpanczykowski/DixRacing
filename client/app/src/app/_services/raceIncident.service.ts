import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RaceIncidentAppealDto } from 'app/_models/raceIncidentAppealDto';
import { RaceIncidentDto } from 'app/_models/raceIncidentDto';
import { RoundIncidents } from 'app/_models/RaceIncidentResult';
import { RaceIncidentSolveDto } from 'app/_models/raceIncidentSolveDto';
import { environment } from 'environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json-patch+json' }),
};

@Injectable({
  providedIn: 'root'
})
export class RaceIncidentService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getRoundIncidents(roundId:number){
    return this.http.get<RoundIncidents>(this.baseUrl+'RaceIncident/'+roundId)
  }

  reportIncident(raceIncidentDto: RaceIncidentDto) {
    return this.http.post(
      this.baseUrl + 'RaceIncident/add',
      JSON.stringify({ raceIncidentDto }),
      httpOptions
    );
  }

  solveTicket(raceIncidentSolveDto: RaceIncidentSolveDto) {
    return this.http.put(this.baseUrl + 'RaceIncident/solve', JSON.stringify({ raceIncidentSolveDto }), httpOptions);
  }

  raiseAppeal(raceIncidentAppealDto: RaceIncidentAppealDto){
    return this.http.put(
      this.baseUrl + 'RaceIncident/appeal',
      JSON.stringify({ raceIncidentAppealDto }),
      httpOptions
    );
  }
}

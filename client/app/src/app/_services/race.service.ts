import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PreqStatus } from 'app/_models/preqStatus';
import { PreqStatusDto } from 'app/_models/preqStatusDto';
import { RaceIncidentDto } from 'app/_models/raceIncidentDto';
import { RaceIncidentSolveDto } from 'app/_models/raceIncidentSolveDto';
import { environment } from 'environments/environment';
import { Race } from '../_models/race';
import { RaceResult } from '../_models/raceResult';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json-patch+json' }),
};

@Injectable({
  providedIn: 'root',
})
export class RaceService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getRaces(roundId: number) {
    return this.http.get<Race[]>(this.baseUrl + 'round/' + roundId + '/races');
  }
  //TODO: controller na get race, quali, preq results
  getRaceResults(raceId: number, sessionType: string) {
    return this.http.get<RaceResult[]>(
      this.baseUrl + 'race/' + raceId + '/results/' + sessionType
    );
  }

  changeRaceStatus(userStatusDto: PreqStatusDto) {
    return this.http.post(
      this.baseUrl + 'race/racestatus/change',
      JSON.stringify({ userStatusDto }),
      httpOptions
    ); //TODO: co zwraca post
  }

  checkUserStatus(userStatusDto: PreqStatusDto) {
    let params = new HttpParams();
    params = params.append('raceId', userStatusDto.raceId.toString());
    params = params.append('userId', userStatusDto.userId.toString());

    return this.http.get<PreqStatus>(this.baseUrl + 'race/confirmation', {
      params: params,
    });
  }

  reportIncident(raceIncidentDto: RaceIncidentDto) {
    return this.http.post(
      this.baseUrl + 'reportIncident',
      JSON.stringify({ raceIncidentDto }),
      httpOptions
    );
  }

  closeTicket(raceIncidentSolveDto: RaceIncidentSolveDto) {
    return this.http.post(this.baseUrl + 'solveIncident/' + raceIncidentSolveDto.ticketId, JSON.stringify({ raceIncidentSolveDto }), httpOptions);
  }

  openTicket(raceIncidentSolveDto: RaceIncidentSolveDto) {
    return this.http.post(this.baseUrl + 'openIncident/' + raceIncidentSolveDto.ticketId, JSON.stringify({ raceIncidentSolveDto }), httpOptions);
  }

  raiseAppeal(raceIncidentDto: RaceIncidentDto){
    return this.http.post(
      this.baseUrl + 'reportIncident',
      JSON.stringify({ raceIncidentDto }),
      httpOptions
    );
  }
}

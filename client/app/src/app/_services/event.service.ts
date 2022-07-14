import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EventCar } from '../_models/eventCar';
import { EventRace } from '../_models/eventRace';
import { EventClassifications} from '../_models/eventClassifications';
import { environment } from 'environments/environment';
import { Events } from '../_models/eventWithActiveRound';
import { EventTeamsWithDrivers, Team } from '../_models/team';
import { EventCreateDto } from 'app/_models/eventCreateDto';
import { Round } from 'app/_models/round';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json-patch+json' }),
};

@Injectable({
  providedIn: 'root',
})
export class EventService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getActiveEvents() {
    return this.http.get<Events>(this.baseUrl + 'event');
  }

  getEventResults(eventId: number) {
    return this.http.get<EventClassifications>(
      this.baseUrl + 'event/' + eventId + '/classification'
    );
  }

  getRacesForEvent(eventId: number) {
    return this.http.get<EventRace>(
      this.baseUrl + 'event/' + eventId + '/races'
    );
  }

  getCarsForEvent(eventId: number) {
    return this.http.get<EventCar>(this.baseUrl + 'event/' + eventId + '/cars');
  }

  getTeamsForEvent(eventId: number) {
    return this.http.get<Team>(this.baseUrl + 'event/' + eventId + '/teams');
  }

  getTeamsWithDriversForEvent(eventId: number) {
    return this.http.get<EventTeamsWithDrivers>(this.baseUrl + 'event/' + eventId + '/teams/detailed');
  }

  eventSignup(eventId: number, eventRegisterDriverDto: any) {
    return this.http.post(
      this.baseUrl + 'event/sign',
      JSON.stringify(eventRegisterDriverDto),
      httpOptions
    );
  }

  // TODO: zmienić team na id i nazwę
  // addNewTeam(eventId: number, newTeamName: string) {
  //   return this.http.post(
  //     this.baseUrl + 'addNewTeam/' + eventId,
  //     JSON.stringify(newTeamName),
  //     httpOptions
  //   );
  // }

  createEvent(eventCreateDto: EventCreateDto) {
    return this.http.post(
      this.baseUrl + 'event',
      JSON.stringify(eventCreateDto),
      httpOptions
    );
  }
  getRounds(eventId: number) {
    return this.http.get(
      this.baseUrl + 'event/' + eventId + '/rounds'
    );
  }

  getPastEvents(){
    return this.http.get<Events>(this.baseUrl+'event'); //TODO ustalić jak ma wyglądać interface dla past events
  }
}

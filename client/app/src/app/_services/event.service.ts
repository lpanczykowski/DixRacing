import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { EventCar } from "../_models/eventCar";
import { EventRace } from "../_models/eventRace";
import { EventResult } from "../_models/eventResult";
import { Events } from "../_models/eventWithActiveRound";
import { Team } from "../_models/team";

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json-patch+json'})
};

@Injectable({
  providedIn: 'root'
})
export class EventService {
  baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
  }

  getActiveEvents()
  {
    return this.http.get<Events>(this.baseUrl+'event');
  }

  getEventResults(eventId:number) {
    return this.http.get<EventResult>(this.baseUrl+'event/'+eventId+'/classification');
  }

  getRacesForEvent(eventId:number) {
    return this.http.get<EventRace>(this.baseUrl+'event/'+eventId+'/races');
  }

  getCarsForEvent(eventId:number){
    return this.http.get<EventCar>(this.baseUrl+'event/'+eventId+'cars');
  }

  getTeamsForEvent(eventId:number){
    return this.http.get<Team>(this.baseUrl+'event/'+eventId+'teams');
  }

  eventSignup(eventId:number,eventRegisterDriverDto:any){
    return this.http.post(this.baseUrl+'event/'+eventId+'/register',JSON.stringify({eventRegisterDriverDto}),httpOptions);
  }

}




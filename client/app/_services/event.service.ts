import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Events, EventWithActiveRound } from "_models/eventWithActiveRound";
import { RaceEvent } from "../_models/event"

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

}

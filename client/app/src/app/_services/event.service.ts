import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Events } from "../_models/eventWithActiveRound";

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

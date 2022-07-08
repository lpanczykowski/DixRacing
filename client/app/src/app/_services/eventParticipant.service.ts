import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { BaseSerivce } from './baseSerivce.cs.service';

@Injectable({
  providedIn: 'root'
})
export class EventParticipantService{

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

 getIsEventParticipant(eventId: number)
  {
    return this.http.get<boolean>(this.baseUrl + 'EventParticipant/eventId/' + eventId );
  }
}

import { Component, OnInit } from '@angular/core';
import { EventService } from 'app/_services/event.service';
import { Events } from 'app/_models/eventWithActiveRound';
import { EventResult } from 'app/_models/eventResult';

@Component({
  selector: 'app-user-leagues',
  templateUrl: './user-leagues.component.html',
  styleUrls: ['./user-leagues.component.css']
})
export class UserLeaguesComponent implements OnInit {

  events: Events;
  eventResults: EventResult[] = [
    { position: 1,
      driverName: 'Dario',
      driverSurname: 'Solaris',
      driverNumber: 71,
      car: 1,
      carNumber: 23,
      penaltyPoints: 15,
      teamName: 'floryda',
      points: 150,
      racePoints: [1, 2, 3, 4, 5, 6] }];
  constructor(private eventService:EventService) { }

  ngOnInit(): void {
    this.loadEvents();
  }
  loadEvents() {
    this.eventService.getPastEvents().subscribe(res =>{
      this.events = res;
    });
   }
}

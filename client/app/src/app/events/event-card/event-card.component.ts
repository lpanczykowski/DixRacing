import { Component, Input, OnInit } from '@angular/core';
import { EventResult } from 'app/_models/eventResult';
import { Events, EventWithActiveRound } from 'app/_models/eventWithActiveRound';
import { EventService } from 'app/_services/event.service';

@Component({
  selector: 'app-event-card',
  templateUrl: './event-card.component.html',
  styleUrls: ['./event-card.component.css']
})
export class EventCardComponent implements OnInit {
  @Input() raceEvent: EventWithActiveRound;

  events: Events;
  eventResults: EventResult[];
  eventId:1;
  eventResult={ position: 1,
    driverName: 'Dario',
    driverSurname: 'Solaris',
    driverNumber: 71,
    car: 1,
    carNumber: 23,
    penaltyPoints: 15,
    teamName: 'floryda',
    points: 150,
    racePoints: [1, 2, 3, 4, 5, 6] };

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.loadEvents();
    this.loadEventResults();
  }

  loadEvents() {
   this.eventService.getActiveEvents().subscribe(res =>{
     this.events = res;
   });
  }
  loadEventResults(){
  this.eventService.getEventResults(this.eventId);
  }
}

import { Component, OnInit } from '@angular/core';
import { Events } from '_models/eventWithActiveRound';

import { EventService } from '_services/event.service';


@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {

  events: Events;
  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.loadEvents();

  }

  loadEvents() {
   this.eventService.getActiveEvents().subscribe(res =>{
     this.events = res;
     console.log(this.events);
   });
  }

}

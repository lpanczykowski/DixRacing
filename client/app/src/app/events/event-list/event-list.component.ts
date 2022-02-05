import { Component, OnInit } from '@angular/core';
import { RaceEvent } from '_models/event';
import { EventsWithActiveRound } from '_models/eventWithActiveRound';
import { EventService } from '_services/event.service';


@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {

  events: EventsWithActiveRound[];
  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.loadEvents();
    console.log(this.events);

  }

  loadEvents() {
   this.eventService.getActiveEvents().subscribe(res =>{
     this.events = res;
     console.log(res);

   });
  }

}

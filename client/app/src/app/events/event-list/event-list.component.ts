import { Component, OnInit } from '@angular/core';
import { RaceEvent } from '_models/event';
import { EventService } from '_services/event.service';


@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {

  events: RaceEvent[];
  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.loadEvents();
    console.log(this.events);

  }

  loadEvents() {
   this.eventService.getActiveEvents().subscribe(res =>{
     this.events = res;
   });
  }

}

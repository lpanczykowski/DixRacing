import { Component, OnInit } from '@angular/core';
import { Events } from 'app/_models/eventWithActiveRound';
import { EventService } from 'app/_services/event.service';


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
   this.eventService.getAllEvents().subscribe(res =>{
     this.events = res;
   });
  }

}

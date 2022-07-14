import { Component, Input, OnInit } from '@angular/core';
import { EventClassifications} from 'app/_models/eventClassifications';
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
  eventResults: EventClassifications[];

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
  //this.eventService.getEventResults(this.eventId);
  }
}

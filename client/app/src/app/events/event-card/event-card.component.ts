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
  disabled : boolean = false;


  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    console.log(this.raceEvent);
  }

  loadEvents() {
  }
  loadEventResults(){
  }
}

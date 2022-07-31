import { Component, Input, OnInit } from '@angular/core';
import { Events, EventWithActiveRounds } from 'app/_models/eventWithActiveRound';
import { EventService } from 'app/_services/event.service';

@Component({
  selector: 'app-event-card',
  templateUrl: './event-card.component.html',
  styleUrls: ['./event-card.component.css']
})
export class EventCardComponent implements OnInit {
  @Input() raceEvent: EventWithActiveRounds;
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

import { EventService } from 'app/_services/event.service';
import { RoundService } from 'app/_services/round.service';
import { Component, Input, OnInit } from '@angular/core';
import { Round } from 'app/_models/round';

@Component({
  selector: 'app-event-rounds',
  templateUrl: './event-rounds.component.html',
  styleUrls: ['./event-rounds.component.css'],
})
export class EventRoundsComponent implements OnInit {
  constructor(private eventService: EventService) {}
  @Input() rounds : Round[]

  ngOnInit() {

  }
  getRoundsForEvent(eventId: number) {
    this.eventService.getRounds(eventId);
  }
}

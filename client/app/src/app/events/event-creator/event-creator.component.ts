import { Component, OnInit } from '@angular/core';
import { EventCreateDto } from 'app/_models/eventCreateDto';
import { EventService } from 'app/_services/event.service';

@Component({
  selector: 'app-event-creator',
  templateUrl: './event-creator.component.html',
  styleUrls: ['./event-creator.component.css']
})
export class EventCreatorComponent implements OnInit {

  model: EventCreateDto
  constructor(private eventService:EventService) { }

  ngOnInit(): void {
  }

  createEvent(){
    this.eventService.createEvent(this.model);
  }
}

import { Component, OnInit } from '@angular/core';
import { Events, EventWithActiveRounds } from 'app/_models/eventWithActiveRound';
import { EventService } from 'app/_services/event.service';

@Component({
  selector: 'app-admin-event-list',
  templateUrl: './admin-event-list.component.html',
  styleUrls: ['./admin-event-list.component.css']
})
export class AdminEventListComponent implements OnInit {

  events: EventWithActiveRounds[];

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents() {
    this.eventService.getAllEvents()
        .subscribe(x => { this.events = x.events },
          (error: any) => { console.log("Błąd przy pobieraniu eventów: " + error) });
  }

}

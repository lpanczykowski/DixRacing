import { Component, OnInit } from '@angular/core';
import { EventService } from 'app/_services/event.service';
import { Events } from 'app/_models/eventWithActiveRound';
import { EventClassifications} from 'app/_models/eventClassifications';

@Component({
  selector: 'app-user-leagues',
  templateUrl: './user-leagues.component.html',
  styleUrls: ['./user-leagues.component.css']
})
export class UserLeaguesComponent implements OnInit {

  events: Events;
  eventResults: EventClassifications[];
  constructor(private eventService:EventService) { }

  ngOnInit(): void {
    //this.loadEvents();
  }
  loadEvents() {
    this.eventService.getPastEvents().subscribe(res =>{
      this.events = res;
    });
   }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventRace } from 'src/app/_models/eventRace';
import { EventResult } from 'src/app/_models/eventResult';
import { EventService } from 'src/app/_services/event.service';

@Component({
  selector: 'app-event-results',
  templateUrl: './event-results.component.html',
  styleUrls: ['./event-results.component.css']
})

export class EventResultsComponent implements OnInit {

  eventId:number;
  raceId:number;
  eventRaces: EventRace[]=[{raceId:1},{raceId:2},{raceId:3},{raceId:4},{raceId:5},{raceId:6}];
  eventResults: EventResult[] = [
    { Position: 1,
      DriverName: 'Dario',
      DriverSurname: 'Solaris',
      DriverNumber: 71,
      Car: 1,
      PenaltyPoints: 15,
      TeamName: 'floryda',
      Points: 150,
      RacePoints: [1, 2, 3, 4, 5, 6] }];

  constructor(private route: ActivatedRoute, private eventService: EventService) { }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    //this.getEventResults(this.eventId);
    //this.getRacesForEvent(this.eventId);
  }

  getEventResults(eventId:number) {
      this.eventService.getEventResults(eventId);
  }

  getRacesForEvent(eventId:number) {
    this.eventService.getRacesForEvent(eventId);
  }
}

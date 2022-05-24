import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from 'app/_services/event.service';
import { EventRace } from 'app/_models/eventRace';
import { EventResult } from 'app/_models/eventResult';
import { RaceService } from 'app/_services/race.service';


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
    { position: 1,
      driverName: 'Dario',
      driverSurname: 'Solaris',
      driverNumber: 71,
      car: 1,
      carNumber: 23,
      penaltyPoints: 15,
      teamName: 'floryda',
      points: 150,
      racePoints: [1, 2, 3, 4, 5, 6] }];

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

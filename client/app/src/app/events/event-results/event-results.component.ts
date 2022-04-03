import { Component, OnInit } from '@angular/core';
import { EventRace } from '_models/eventRace';
import { EventResult } from '_models/eventResult';
import { RaceService } from '_services/race.service';

@Component({
  selector: 'app-event-results',
  templateUrl: './event-results.component.html',
  styleUrls: ['./event-results.component.css']
})

export class EventResultsComponent implements OnInit {
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

  constructor(private raceService: RaceService) { }

  ngOnInit(): void {

  }

  getEventResults() {

  }

  getRaceResults() {
    //this.raceService.getRaceResults(this.raceId, this.resultsSelector);
  }
}

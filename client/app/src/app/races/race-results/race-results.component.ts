import { Component, Input, OnInit } from '@angular/core';
import { MatCardActions } from '@angular/material/card';
import { ActivatedRoute } from '@angular/router';
import { RaceResult } from '../../_models/raceResult';
import { RaceService } from '../../_services/race.service';


@Component({
  selector: 'app-race-results',
  templateUrl: './race-results.component.html',
  styleUrls: ['./race-results.component.css']
})
export class RaceResultsComponent implements OnInit {
  @Input() resultsSelector: string;
  currentResults: string;
  raceId:number;
  raceResults: RaceResult[] = [{ DriverNumber: 830, DriverName: 'Marcin', DriverSurname: 'Lewandowski',TeamName:'SMR Racing', Car:1, Sector1Time:39, Sector2Time: 68, Sector3Time:27, Laps: 50, PenaltyPoints: 0, Points: 100, Position: 1, RaceId: 1, Time: 1995, Gap:0 },
                                { DriverNumber: 730, DriverName: 'Marcin', DriverSurname: 'Lewandowski',TeamName:'SMR Racing', Car:1, Sector1Time:35, Sector2Time: 59, Sector3Time:21, Laps: 50, PenaltyPoints: 0, Points: 90, Position: 2, RaceId: 1, Time: 1990, Gap:5 },
                                { DriverNumber: 930, DriverName: 'Marcin', DriverSurname: 'Lewandowski',TeamName:'SMR Racing', Car:1, Sector1Time:31, Sector2Time: 61, Sector3Time:28, Laps: 50, PenaltyPoints: 5, Points: 80, Position: 3, RaceId: 1, Time: 1980, Gap:15 }];

  constructor(private route: ActivatedRoute, private raceService: RaceService) { }

  ngOnInit(): void {
    this.raceId = Number(this.route.snapshot.paramMap.get('raceId'));
    //this.loadView();
  }

  loadView() {
    this.raceService.getRaceResults(this.raceId,this.resultsSelector);
  }
}

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
  @Output() numberOfParticipantsEmitter= new EventEmitter<number>();

  body = document.getElementById('raceResultsTable')
  currentResults: string;
  raceId:number;
  raceResults: RaceResult[] = [{driverNumber: 830,
                                driverName: 'Marcin',
                                driverSurname: 'Lewandowski',
                                teamName:'SMR Racing',
                                car:1,
                                carNumber:830,
                                sector1Time:39,
                                sector2Time: 68,
                                sector3Time:27,
                                laps: 50,
                                penaltyPoints: 0,
                                points: 100,
                                position: 1,
                                raceId: 1,
                                time: 1995,
                                gap:0 },
                                { driverNumber: 730,
                                  driverName: 'Marcin',
                                  driverSurname: 'Lewandowski',
                                  teamName:'SMR Racing',
                                  car:1,
                                  carNumber:842,
                                  sector1Time:35,
                                  sector2Time: 59,
                                  sector3Time:21,
                                  laps: 50,
                                  penaltyPoints: 0,
                                  points: 90,
                                  position: 2,
                                  raceId: 1,
                                  time: 1990,
                                  gap:5 },
                                { driverNumber: 930,
                                  driverName: 'Marcin',
                                  driverSurname: 'Lewandowski',
                                  teamName:'SMR Racing',
                                  car:1,
                                  carNumber:412,
                                  sector1Time:31,
                                  sector2Time: 61,
                                  sector3Time:28,
                                  laps: 50,
                                  penaltyPoints: 5,
                                  points: 80,
                                  position: 3,
                                  raceId: 1,
                                  time: 1980,
                                  gap:15 }];

  constructor(private route: ActivatedRoute, private raceService: RaceService) { }

  ngOnInit(): void {
    this.raceId = Number(this.route.snapshot.paramMap.get('raceId'));
    //this.loadView();
    let participantCount=this.body.childNodes.length
    this.numberOfRaceParticipants(participantCount)
  }

  loadView() {
    this.raceService.getRaceResults(this.raceId,this.resultsSelector);
  }

  numberOfRaceParticipants(participants:number)
  {
    this.numberOfParticipantsEmitter.emit(participants);
  }

}

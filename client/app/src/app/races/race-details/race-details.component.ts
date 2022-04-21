import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventResult } from 'app/_models/eventResult';
import { RaceResult } from 'app/_models/raceResult';
import { PreqStatusDto } from 'app/_models/preqStatusDto';
import { RaceService } from 'app/_services/race.service';
import { PreqStatus } from 'app/_models/preqStatus';

@Component({
  selector: 'app-race-details',
  templateUrl: './race-details.component.html',
  styleUrls: ['./race-details.component.css'],
})
export class RaceDetailsComponent implements OnInit {
  numberOfParticipantsForEvent: number;
  userStatusInfo: PreqStatusDto = new PreqStatusDto();
  raceId: string;
  eventId: string;
  roundId: string;
  userId: number;
  view: string;
  preqStatus: PreqStatus;
  currentDriverResult: RaceResult = {
    name: 'Marcin',
    surname: 'Lewandowski',
    teamName: 'SMR Racing',
    car: 'Porsche',
    carNumber: 830,
    raceId: 1,
    time: 1980,
    gap: 15,
    nick: 'Fevio',
    bestLap: { lap: 2100, isValid: 1, split1: 1, split2: 1, split3: 3 },
    position: { points: 100, position: 1 },
    userId: 1,
    laps: []
  };

  constructor(
    private route: ActivatedRoute,
    private raceService: RaceService
  ) {}

  ngOnInit(): void {
    this.view = this.route.snapshot.paramMap.get('view');
    this.eventId = this.route.snapshot.paramMap.get('eventId');
    this.roundId = this.route.snapshot.paramMap.get('roundId');
    this.raceId = this.route.snapshot.paramMap.get('raceId');
    //this.checkPreqStatus(this.raceId,this.userId);
    //this.userStatusInfo = { raceId: this.raceId, userId: this.userId }
    //this.checkPreqStatus();
  }

  setCurrentView(view: string) {
    this.view = view;
  }

  getNumberOfParticipants(gridSize: number) {
    this.numberOfParticipantsForEvent = gridSize;
  }

  checkPreqStatus() {
    this.raceService
      .checkUserStatus(this.userStatusInfo)
      .subscribe((response) => {
        this.preqStatus = response;
      }),
      (error) => console.log(error);
  }

  changeRaceStatus() {
    this.raceService.changeRaceStatus(this.userStatusInfo);
  }
}

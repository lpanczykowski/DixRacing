import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventResult } from 'app/_models/eventResult';
import { RaceResult } from 'app/_models/raceResult';
import { UserStatusDto } from 'app/_models/userStatusDto';
import { RaceService } from 'app/_services/race.service';

@Component({
  selector: 'app-race-details',
  templateUrl: './race-details.component.html',
  styleUrls: ['./race-details.component.css']
})
export class RaceDetailsComponent implements OnInit {
  numberOfParticipantsForEvent:number;
  userStatusInfo:UserStatusDto = new UserStatusDto();
  raceId:number;
  userId:number;
  view:string;

  constructor(private route: ActivatedRoute, private raceService: RaceService) { }
  currentDriverResult: RaceResult={ driverNumber: 930,
                                    driverName: 'Marcin',
                                    driverSurname: 'Lewandowski',
                                    teamName:'SMR Racing',
                                    car:1,
                                    carNumber:830,
                                    sector1Time:31,
                                    sector2Time: 61,
                                    sector3Time:28,
                                    laps: 50,
                                    penaltyPoints: 5,
                                    points: 80,
                                    position: 1,
                                    raceId: 1,
                                    time: 1980,
                                    gap:15 }

  ngOnInit(): void {
    this.view = this.route.snapshot.paramMap.get('view');
    this.view = this.route.snapshot.paramMap.get('raceId');
     }

  setCurrentView(view: string) {
    this.view = view;
  }

  getNumberOfParticipants(gridSize:number)
  {
     this.numberOfParticipantsForEvent=gridSize;
    }

  checkUserStatus(raceId:number,userId:number){

    raceId=this.raceId;
    userId=this.userId; //TODO:wyciagnięcie userId ze storage strony
    this.raceService.checkUserStatus(raceId,userId);
  }

  changeRaceStatus(){
    this.userStatusInfo.raceId=this.raceId;
    this.userStatusInfo.userId=1;
    // this.userStatusInfo.userId=this.userId; TODO:wyciagnięcie userId ze storage strony
    this.raceService.changeRaceStatus(this.userStatusInfo);
  }
}

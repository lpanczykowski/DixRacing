import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RaceIncidentDto } from 'app/_models/raceIncidentDto';
import { RaceIncidentResult } from 'app/_models/RaceIncidentResult';
import { RaceService } from 'app/_services/race.service';
@Component({
  selector: 'app-race-incidents',
  templateUrl: './race-incidents.component.html',
  styleUrls: ['./race-incidents.component.css']
})
export class RaceIncidentsComponent implements OnInit {
  raceIncidents: RaceIncidentResult[] = [{incidentId: 1,
                                    reportingDriver: 830,
                                    reportedDriver: 831,
                                    incidentLap: 60,
                                    incidentTime: '123',
                                    incidentDescription:'damn1',
                                    result: 'RI',
                                    solved:true},
                                    {incidentId: 2,
                                     reportingDriver: 80,
                                     reportedDriver: 131,
                                     incidentLap: 1,
                                     incidentTime: '123',
                                     incidentDescription:'damn2',
                                     result: '-15 Points',
                                     solved:true},
                                  {incidentId: 3,
                                    reportingDriver: 130,
                                    reportedDriver: 811,
                                    incidentLap: 2,
                                    incidentTime: '123',
                                    incidentDescription:'damn3',
                                    result: '+48 sec',
                                    solved:true}];


  params:HttpParams ;
  eventId :number;
  displayAppeal:boolean;
  currentDriverNumber:number;
  model:RaceIncidentDto=new RaceIncidentDto();
  constructor(private raceService:RaceService,private route :ActivatedRoute) { }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.params = new HttpParams().set('eventId',this.eventId.toString())
    console.log(this.params);
  }

  showDisplayAppeal(){
    this.displayAppeal=true;
  }

  raiseAppeal(raceIncident:RaceIncidentResult){
    this.displayAppeal=false;
    this.model.lap=raceIncident.incidentLap;
    this.model.time=raceIncident.incidentTime;
    this.model.reportedUserId=raceIncident.reportedDriver;
    this.model.userId=raceIncident.reportingDriver;
    this.model.isSolved=false;
    this.raceService.raiseAppeal(this.model);
  }

}

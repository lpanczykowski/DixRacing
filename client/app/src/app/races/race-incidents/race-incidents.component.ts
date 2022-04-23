import { Component, OnInit } from '@angular/core';
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


  displayAppeal:boolean;
  currentDriverNumber:number;
  model:RaceIncidentDto=new RaceIncidentDto();
  constructor(private raceService:RaceService) { }

  ngOnInit(): void {
    this.currentDriverNumber=830;
  }

  showDisplayAppeal(){
    this.displayAppeal=true;
  }

  raiseAppeal(raceIncident:RaceIncidentResult){
    this.displayAppeal=false;
    this.model.incidentLap=raceIncident.incidentLap;
    this.model.incidentTime=raceIncident.incidentTime;
    this.model.reportedDriver=raceIncident.reportedDriver;
    this.model.reportingDriver=raceIncident.reportingDriver;
    this.model.solved=false;
    this.raceService.raiseAppeal(this.model);
  }

}

import { Component, OnInit } from '@angular/core';
import { RaceIncidentResult } from 'app/_models/RaceIncidentResult';
import { RaceIncidentSolveDto } from 'app/_models/raceIncidentSolveDto';
import { RaceService } from 'app/_services/race.service';

@Component({
  selector: 'app-race-incidents-open',
  templateUrl: './race-incidents-open.component.html',
  styleUrls: ['./race-incidents-open.component.css']
})
export class RaceIncidentsOpenComponent implements OnInit {

  raceIncidents: RaceIncidentResult[] = [{incidentId: 1,
    reportingDriver: 830,
    reportedDriver: 831,
    incidentLap: 60,
    incidentTime: '123',
    incidentDescription:'damn1',
    result: 'RI',
    solved: false},
    {incidentId: 2,
     reportingDriver: 80,
     reportedDriver: 131,
     incidentLap: 1,
     incidentTime: '123',
     incidentDescription:'damn2',
     result: '-15 Points',
     solved: false},
  {incidentId: 3,
    reportingDriver: 130,
    reportedDriver: 811,
    incidentLap: 2,
    incidentTime: '123',
    incidentDescription:'damn3',
    result: '+48 sec',
    solved: true,}];


constructor(private raceService:RaceService) { }

ngOnInit(): void {
}

closeTicket(raceIncident:RaceIncidentSolveDto){
  raceIncident.solved=true;
  console.log(raceIncident);
  this.raceService.closeTicket(raceIncident);
}

openTicket(raceIncident:RaceIncidentSolveDto){
  raceIncident.solved=false;
  this.raceService.openTicket(raceIncident);
}

hideRow(incidentId:number){
   var row=document.getElementById("incidentRow"+incidentId);
  row.style.display="none";
}

}


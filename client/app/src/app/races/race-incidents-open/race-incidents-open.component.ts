import { Component, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RaceIncidentAppealDto } from 'app/_models/raceIncidentAppealDto';
import { RaceIncidentById, RaceIncidents } from 'app/_models/RaceIncidentResult';
import { RaceIncidentSolveDto } from 'app/_models/raceIncidentSolveDto';
import { RaceService } from 'app/_services/race.service';
import { RaceIncidentService } from 'app/_services/raceIncident.service';
import { RoundService } from 'app/_services/round.service';

@Component({
  selector: 'app-race-incidents-open',
  templateUrl: './race-incidents-open.component.html',
  styleUrls: ['./race-incidents-open.component.css']
})
export class RaceIncidentsOpenComponent implements OnInit {
@Output() raceIncident:RaceIncidentById;
roundIncidents:RaceIncidents[];
raceIncidents:RaceIncidentById[];
solveIncident:RaceIncidentSolveDto=new RaceIncidentSolveDto();
roundId:number;
raceIncidentId:number;
model:RaceIncidentSolveDto=new RaceIncidentSolveDto();

constructor(private raceIncidentService:RaceIncidentService, private roundService:RoundService,private route:ActivatedRoute) { }

ngOnInit(): void {
  this.roundId = Number(this.route.snapshot.paramMap.get('roundId'));
  this.getRoundIncidents(this.roundId);
}


openTicket(raceIncident:RaceIncidentById){
  this.solveIncident.isSolved=0;
  this.solveIncident.id=raceIncident.id;
  this.solveIncident.pointPenalty=raceIncident.pointPenalty;
  this.solveIncident.penalty=raceIncident.penalty;
  this.raceIncidentService.solveTicket(this.solveIncident).subscribe(()=>
  this.getRoundIncidents(this.roundId));
}

getRoundIncidents(roundId:number){
  this.raceIncidentService.getRoundIncidents(roundId).subscribe(data=>{
  this.raceIncidents=data.roundIncidents.flatMap(x=>x.raceIncidents);})
}

updateRaceIncidents(raceIncidents:RaceIncidentById[]){
  this.raceIncidents=raceIncidents;
}

}


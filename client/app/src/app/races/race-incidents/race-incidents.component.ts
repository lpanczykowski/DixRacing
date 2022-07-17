import { HttpParams } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RaceIncidentAppealDto } from 'app/_models/raceIncidentAppealDto';
import { RaceIncidentDto } from 'app/_models/raceIncidentDto';
import { RaceIncidentById, RaceIncidents, RoundIncidents } from 'app/_models/RaceIncidentResult';
import { RaceService } from 'app/_services/race.service';
import { RaceIncidentService } from 'app/_services/raceIncident.service';
import { RoundService } from 'app/_services/round.service';
@Component({
  selector: 'app-race-incidents',
  templateUrl: './race-incidents.component.html',
  styleUrls: ['./race-incidents.component.css']
})
export class RaceIncidentsComponent implements OnInit {
  roundIncidents:RaceIncidents[];
  raceIncidents:RaceIncidentById[];
  params:HttpParams ;
  eventId :number;
  roundId:number;
  incidentId:number;
  displayAppeal:boolean;
  currentDriverNumber:number;
  model:RaceIncidentAppealDto= new RaceIncidentAppealDto();
  constructor(private raceIncidentService:RaceIncidentService,private route :ActivatedRoute,private roundService:RoundService) { }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.params = new HttpParams().set('eventId',this.eventId.toString())
    this.roundId = Number(this.route.snapshot.paramMap.get('roundId'));
    this.getRoundIncidents(this.roundId);
  }

  showDisplayAppeal(){
    this.displayAppeal=true;
  }

  raiseAppeal(incidentId:number){
    this.displayAppeal=false;
    this.model.id=incidentId;
    this.raceIncidentService.raiseAppeal(this.model).subscribe();
    this.ngOnInit;
  }

  getRoundIncidents(roundId:number){
    this.raceIncidentService.getRoundIncidents(roundId).subscribe(data=>{
    this.raceIncidents=data.roundIncidents.flatMap(x=>x.raceIncidents);
  })
  }
}

import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RaceIncidentById, RaceIncidents } from 'app/_models/RaceIncidentResult';
import { RaceIncidentSolveDto } from 'app/_models/raceIncidentSolveDto';
import { RaceService } from 'app/_services/race.service';
import { RaceIncidentService } from 'app/_services/raceIncident.service';

@Component({
  selector: 'app-penalty-solve-form',
  templateUrl: './penalty-solve-form.component.html',
  styleUrls: ['./penalty-solve-form.component.css']
})
export class PenaltySolveFormComponent implements OnInit {

  model:RaceIncidentSolveDto=new RaceIncidentSolveDto();
  roundId:number;
  @Output() raceIncidentsEmitter=new EventEmitter<RaceIncidentById[]>();
  raceIncidents:RaceIncidentById[];
  @Input() raceIncident:RaceIncidentById;

  constructor(private raceIncidentService:RaceIncidentService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.roundId = Number(this.route.snapshot.paramMap.get('roundId'));
  }

  closeTicket(raceIncident:RaceIncidentById){
    this.model.id=raceIncident.id;
    this.model.isSolved=1;
    this.raceIncidentService.solveTicket(this.model).subscribe(()=>{
    this.getRoundIncidents(this.roundId);
    this.raceIncident=null;
    })
  }

  getRoundIncidents(roundId:number){
    this.raceIncidentService.getRoundIncidents(roundId).subscribe(data=>{
    this.raceIncidents=data.roundIncidents.flatMap(x=>x.raceIncidents);
    this.raceIncidentsEmit(this.raceIncidents)})
  }

  raceIncidentsEmit(raceIncidents:RaceIncidentById[]){
    this.raceIncidentsEmitter.emit(raceIncidents);
  }
}

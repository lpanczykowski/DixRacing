import { HttpParams } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DropdownValue } from 'app/_models/dropdown';
import { RaceIncidentDto } from 'app/_models/raceIncidentDto';
import { RaceIncidents } from 'app/_models/RaceIncidentResult';
import { RaceService } from 'app/_services/race.service';
import { RaceIncidentService } from 'app/_services/raceIncident.service';

@Component({
  selector: 'app-race-incidents-report',
  templateUrl: './race-incidents-report.component.html',
  styleUrls: ['./race-incidents-report.component.css'],
})
export class RaceIncidentsReportComponent implements OnInit {
  roundIncidents: RaceIncidents[];
  model: RaceIncidentDto = new RaceIncidentDto();
  params: HttpParams;
  eventId: number;
  raceId:number;
  userId:number;
  constructor(
    private raceIncidentService: RaceIncidentService,
    private route: ActivatedRoute,
    ) {}

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.raceId = Number(this.route.snapshot.paramMap.get('raceId'));
    this.params = new HttpParams().set('eventId', this.eventId);
    const user = JSON.parse(localStorage.getItem('user'));
    this.userId = user.userId;
  }

  reportIncident() {
    this.model.raceId=this.raceId;
    this.model.userId=this.userId;
    this.raceIncidentService.reportIncident(this.model).subscribe(()=>{
      window.location.reload();
    }
    );
  }

  selectReportedDriver(selectedDriver:number){
    this.model.reportedUserId=selectedDriver;
  }
}

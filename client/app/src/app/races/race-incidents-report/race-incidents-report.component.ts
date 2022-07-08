import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DropdownValue } from 'app/_models/dropdown';
import { RaceIncidentDto } from 'app/_models/raceIncidentDto';
import { RaceService } from 'app/_services/race.service';

@Component({
  selector: 'app-race-incidents-report',
  templateUrl: './race-incidents-report.component.html',
  styleUrls: ['./race-incidents-report.component.css'],
})
export class RaceIncidentsReportComponent implements OnInit {
  model: RaceIncidentDto = new RaceIncidentDto();
  params: HttpParams;
  eventId: number;

  constructor(
    private raceService: RaceService,
    private route: ActivatedRoute,
    ) {}

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.params = new HttpParams().set('eventId', this.eventId);
    console.log(this.params.getAll('eventId'));
  }

  reportIncident(model: RaceIncidentDto) {
    this.model.isSolved = false;
    this.raceService.reportIncident(model);
  }

  selectReportedDriver(selectedDriver:number){
    this.model.reportedUserId=selectedDriver;
  }
}

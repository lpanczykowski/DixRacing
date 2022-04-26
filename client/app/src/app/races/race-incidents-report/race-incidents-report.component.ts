import { Component, OnInit } from '@angular/core';
import { RaceIncidentDto } from 'app/_models/raceIncidentDto';
import { RaceService } from 'app/_services/race.service';

@Component({
  selector: 'app-race-incidents-report',
  templateUrl: './race-incidents-report.component.html',
  styleUrls: ['./race-incidents-report.component.css'],
})
export class RaceIncidentsReportComponent implements OnInit {
  model: RaceIncidentDto = new RaceIncidentDto();

  constructor(private raceService: RaceService) {}

  ngOnInit(): void {}

  reportIncident(model: RaceIncidentDto) {
    this.model.isSolved = false;
    this.raceService.reportIncident(model);
  }
}

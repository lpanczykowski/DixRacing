import { Component, OnInit } from '@angular/core';
import { RaceIncident } from 'app/_models/raceIncident';
@Component({
  selector: 'app-race-incidents',
  templateUrl: './race-incidents.component.html',
  styleUrls: ['./race-incidents.component.css']
})
export class RaceIncidentsComponent implements OnInit {
  raceIncidents: RaceIncident[] = [{IncidentId: 1, ReportingDriver: 830, ReportedDriver: 831, IncidentLap: 60, Result: 'RI'},
                                  {IncidentId: 2, ReportingDriver: 80, ReportedDriver: 131, IncidentLap: 1, Result: '-15 Points'},
                                  {IncidentId: 3, ReportingDriver: 130, ReportedDriver: 811, IncidentLap: 2, Result: '+48 sec'}];
  constructor() { }

  ngOnInit(): void {
  }
}

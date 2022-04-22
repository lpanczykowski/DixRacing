import { Component, OnInit } from '@angular/core';
import { RaceIncidentResult } from 'app/_models/RaceIncidentResult';
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
                                    incidentDescription:'damn1',
                                    result: 'RI'},
                                    {incidentId: 2,
                                     reportingDriver: 80,
                                     reportedDriver: 131,
                                     incidentLap: 1,
                                     incidentDescription:'damn2',
                                     result: '-15 Points'},
                                  {incidentId: 3,
                                    reportingDriver: 130,
                                    reportedDriver: 811,
                                    incidentLap: 2,
                                    incidentDescription:'damn3',
                                    result: '+48 sec'}];
  constructor() { }

  ngOnInit(): void {
  }
}

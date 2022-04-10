import { Component, OnInit } from '@angular/core';
import { RaceIncidentDto } from 'app/_models/raceIncidentDto';
@Component({
  selector: 'app-race-incidents',
  templateUrl: './race-incidents.component.html',
  styleUrls: ['./race-incidents.component.css']
})
export class RaceIncidentsComponent implements OnInit {
  raceIncidents: RaceIncidentDto[] = [{incidentId: 1,
                                    reportingDriver: 830,
                                    reportedDriver: 831,
                                    incidentLap: 60,
                                    incidentDescription:'damn',
                                    result: 'RI'},
                                    {incidentId: 2,
                                     reportingDriver: 80,
                                     reportedDriver: 131,
                                     incidentLap: 1,
                                     incidentDescription:'damn',
                                     result: '-15 Points'},
                                  {incidentId: 3,
                                    reportingDriver: 130,
                                    reportedDriver: 811,
                                    incidentLap: 2,
                                    incidentDescription:'damn',
                                    result: '+48 sec'}];
  constructor() { }

  ngOnInit(): void {
  }
}

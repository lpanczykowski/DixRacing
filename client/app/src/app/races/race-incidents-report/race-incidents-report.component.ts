import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-race-incidents-report',
  templateUrl: './race-incidents-report.component.html',
  styleUrls: ['./race-incidents-report.component.css']
})
export class RaceIncidentsReportComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  reportIncident()
  {
    //TODO:Przekazanie zgloszonego incydentu do DB
  }
}

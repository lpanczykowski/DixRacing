import { Component, Input, OnInit } from '@angular/core';
import { EventWithActiveRounds } from 'app/_models/eventWithActiveRound';

@Component({
  selector: 'app-admin-event-details',
  templateUrl: './admin-event-details.component.html',
  styleUrls: ['./admin-event-details.component.css']
})
export class AdminEventDetailsComponent implements OnInit {
  @Input() event : EventWithActiveRounds
  constructor() { }

  ngOnInit(): void {

  }

}

import { Component, OnInit } from '@angular/core';
import { Events } from 'app/_models/eventWithActiveRound';
import { EventService } from 'app/_services/event.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  events: Events
  constructor(private eventService: EventService) { }

  ngOnInit(): void {

  }

}

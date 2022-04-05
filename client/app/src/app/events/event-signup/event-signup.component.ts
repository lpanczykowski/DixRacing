import { Component, OnInit } from '@angular/core';
import { EventCar } from 'app/_models/eventCar';
import { EventTeam } from 'app/_models/eventTeam';
@Component({
  selector: 'app-event-signup',
  templateUrl: './event-signup.component.html',
  styleUrls: ['./event-signup.component.css']
})
export class EventSignupComponent implements OnInit {
  constructor() { }
  eventCars: EventCar[]=[{car:1},{car:2},{car:3}];
  eventTeams: EventTeam[]=[{teamName:'zurek'},{teamName:'nowyskoski'},{teamName:'teamname'}]
  ngOnInit(): void {
  }

  eventSignup()
  {

  }

  getCarsForEvent()
  {

  }

  createNewTeam()
  {

  }
}

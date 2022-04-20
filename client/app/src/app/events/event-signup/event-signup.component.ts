import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { eventRegisterDriverDto } from 'app/_models/eventRegisterDto';
import { Team } from 'app/_models/Team';
import { EventService } from 'app/_services/event.service';
import { EventCar } from 'app/_models/eventCar';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-event-signup',
  templateUrl: './event-signup.component.html',
  styleUrls: ['./event-signup.component.css'],
  providers: [MessageService]
})
export class EventSignupComponent implements OnInit {


  model: eventRegisterDriverDto = new eventRegisterDriverDto();
  eventId: number;
  userId: number;
  eventCars: EventCar[];
  uploadedFiles:any[]=[];
  eventTeams: Team[] = [{ teamId: 1, teamName: 'teasm1', teamMate: ['LEWIS', 'GEORGE'], teamCar: 7, teamPoints: 50 },
  { teamId: 2, teamName: 'team2', teamMate: ['MAX', 'CHECO'], teamCar: 2, teamPoints: 50 },
  { teamId: 2, teamName: 'team3', teamMate: ['CHARLES', 'CARLOS'], teamCar: 3, teamPoints: 50 }];

  constructor(private route: ActivatedRoute, private eventService: EventService, private router: Router,private messageService: MessageService) {
    this.eventCars = [{ car: 111111111 }, { car: 222222222 }, { car: 333333333 }]
  }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    const user = JSON.parse(localStorage.getItem('user'));
    this.userId = user.userId;

    //this.getCarsForEvent(this.eventId);
    //this.getTeamsForEvent(this.eventId);
  }

  eventSignup() {
    if (this.model.newTeam !== undefined) {
      this.model.team = this.model.newTeam;
      this.addNewTeam(this.eventId, this.model.newTeam);
    };
    this.model.eventId = this.eventId;
    this.model.userId = this.userId;
    this.eventService.eventSignup(this.eventId, this.model);
    this.router.navigateByUrl('/event/' + this.eventId);
    console.log(this.model);
  }

  getCarsForEvent(eventId) {
    this.eventService.getCarsForEvent(eventId);
  }

  getTeamsForEvent(eventId) {
    this.eventService.getTeamsForEvent(eventId);
  }

  addNewTeam(eventId: number, newTeamName: string) {
    this.eventService.addNewTeam(eventId, newTeamName);
  }

}

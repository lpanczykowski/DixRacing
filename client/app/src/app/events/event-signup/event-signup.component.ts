import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { eventRegisterDriverDto } from 'app/_models/eventRegisterDto';
import { Team } from 'app/_models/Team';
import { EventService } from 'app/_services/event.service';
import { EventCar } from 'app/_models/eventCar';
import { MessageService } from 'primeng/api';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-event-signup',
  templateUrl: './event-signup.component.html',
  styleUrls: ['./event-signup.component.css'],
  providers: [MessageService]
})
export class EventSignupComponent implements OnInit {

  params: HttpParams;
  model: eventRegisterDriverDto = new eventRegisterDriverDto();
  eventId: number;
  userId: number;
  eventCars: EventCar[];
  uploadedFiles:any[]=[];
  eventTeams: Team[];

  constructor(private route: ActivatedRoute, private eventService: EventService, private router: Router,private messageService: MessageService) {
    this.eventCars = [{ car: 111111111 }, { car: 222222222 }, { car: 333333333 }]
  }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.params = new HttpParams().set('eventId', this.eventId);
    const user = JSON.parse(localStorage.getItem('user'));
    this.userId = user.userId;

    //this.getCarsForEvent(this.eventId);
    //this.getTeamsForEvent(this.eventId);
  }

  eventSignup() {
    // TODO: Sprawdzenie czy nazwa teamu jest zajęta i dodanie team Id przy tworzeniu nowego
    // if (this.model.newTeam !== undefined) {
    //   this.model.team = this.model.newTeam;
    //   this.addNewTeam(this.eventId, this.model.newTeam);
    // };
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

  // TODO: Sprawdzenie czy nazwa teamu jest zajęta i dodanie team Id przy tworzeniu nowego
  // addNewTeam(eventId: number, newTeamName: string) {
  //   this.eventService.addNewTeam(eventId, newTeamName);
  // }

  liveryUpload(event){
    this.model.livery = event.target.files[0];
  }

  selectCar(selectedCar:number){
    this.model.car=selectedCar;
  }

  selectTeam(selectedTeam:number){
    this.model.team=selectedTeam;
  }
}

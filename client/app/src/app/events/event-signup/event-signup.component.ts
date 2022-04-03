import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventCar } from 'src/app/_models/eventCar';
import { eventRegisterDriverDto } from 'src/app/_models/eventRegisterDto';
import { Team } from 'src/app/_models/Team';
import { EventService } from 'src/app/_services/event.service';
@Component({
  selector: 'app-event-signup',
  templateUrl: './event-signup.component.html',
  styleUrls: ['./event-signup.component.css']
})
export class EventSignupComponent implements OnInit {

  constructor(private route: ActivatedRoute, private eventService: EventService) { }
  model: eventRegisterDriverDto = new eventRegisterDriverDto();
  eventId: number;

  eventCars: EventCar[] = [{ car: 1 }, { car: 2 }, { car: 3 }];
  eventTeams: Team[] = [{teamId:1,teamName:'team1',teamMate:['LEWIS','GEORGE'],teamCar:7,teamPoints:50},
                        {teamId:2,teamName:'team2',teamMate:['MAX','CHECO'],teamCar:2,teamPoints:50},
                        {teamId:2,teamName:'team3',teamMate:['CHARLES','CARLOS'],teamCar:3,teamPoints:50}];
  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    //this.getCarsForEvent(this.eventId);
    //this.getTeamsForEvent(this.eventId);
  }

  eventSignup() {
    this.eventService.eventSignup(this.eventId, this.model);
  }

  getCarsForEvent(eventId) {
    this.eventService.getCarsForEvent(eventId);
  }

  getTeamsForEvent(eventId) {
    this.eventService.getTeamsForEvent(eventId);
  }

}

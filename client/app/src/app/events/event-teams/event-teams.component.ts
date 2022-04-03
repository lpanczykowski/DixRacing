import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Team } from 'src/app/_models/team';
import { EventService } from 'src/app/_services/event.service';

@Component({
  selector: 'app-event-teams',
  templateUrl: './event-teams.component.html',
  styleUrls: ['./event-teams.component.css']
})
export class EventTeamsComponent implements OnInit {

  constructor(private route:ActivatedRoute, private eventService:EventService) { }

  eventId:number;
  teams:Team[]=[{teamId:1,teamName:'team1',teamMate:['LU KAS','MA TI'],teamCar:2,teamPoints:50},
                {teamId:2,teamName:'team2',teamMate:['RO BOT','BUL BAN','Robert Maklowicz'],teamCar:8,teamPoints:40}];

  ngOnInit(): void {

    this.eventId=Number(this.route.snapshot.paramMap.get('eventId'));
    //getTeamsForEvent(this.eventId);
  }

  getTeamsForEvent(eventId){
    this.eventService.getTeamsForEvent(eventId);
  }
}

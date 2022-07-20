import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Team } from 'app/_models/team';
import { EventService } from 'app/_services/event.service';

@Component({
  selector: 'app-event-teams',
  templateUrl: './event-teams.component.html',
  styleUrls: ['./event-teams.component.css'],
})
export class EventTeamsComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private eventService: EventService
  ) {}

  eventId: number;
  teams: Team[];

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.getTeamsWithDriversForEvent(this.eventId);
  }

  getTeamsWithDriversForEvent(eventId:number) {
    this.eventService.getTeamsWithDriversForEvent(eventId).subscribe(data=>{
      this.teams=data.eventTeamsWithDrivers.map(res=>{ return {teamId:res.teamId,
                                                              teamName:res.teamName,
                                                              teamMembers:res.teamMembers,
                                                              teamCar:res.teamCar,
                                                              teamPoints:res.teamPoints}});
    });
  }

  summedPoints(team:Team){
    var totalPoints=0;
    team.teamMembers.forEach(element => {
      totalPoints+=element.summedPoints;
    });
    return totalPoints;
  }
}

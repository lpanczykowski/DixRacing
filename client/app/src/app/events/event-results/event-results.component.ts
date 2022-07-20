import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from 'app/_services/event.service';
import { EventRace } from 'app/_models/eventRace';
import {EventParticipantClassification} from 'app/_models/eventClassifications';
import { RaceService } from 'app/_services/race.service';


@Component({
  selector: 'app-event-results',
  templateUrl: './event-results.component.html',
  styleUrls: ['./event-results.component.css']
})

export class EventResultsComponent implements OnInit {

  eventId:number;
  raceId:number;
  eventResults: EventParticipantClassification[];

  constructor(private route: ActivatedRoute, private eventService: EventService) { }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.getEventResults(this.eventId);
  }

  getEventResults(eventId:number) {
    this.eventService.getEventResults(eventId).subscribe(data=>{ console.log(data)
      this.eventResults=data.eventClassifications.map(res=>{return{eventId:res.eventId,
                                                                  number:res.number,
                                                                  name:res.name,
                                                                  surname:res.surname,
                                                                  teamName:res.teamName,
                                                                  car:res.car,
                                                                  roundsPoints:res.roundsPoints,
                                                                  summedPoints:res.summedPoints,
                                                                  pointPenalty:res.pointPenalty,
                                                                  points:res.summedPoints+res.pointPenalty}});
    });
  }
}

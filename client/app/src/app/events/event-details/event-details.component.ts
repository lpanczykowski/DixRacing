import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventDto } from '_models/event';
import { Race } from '_models/race';
import { Round } from '_models/round';
import { RaceService } from '_services/race.service';
import { RoundService } from '_services/round.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {
  event: EventDto;
  viewId: number;
  activeRound: Round;
  eventId: number;
  races : Race[];
  now : any;
  seconds;minutes;hours : number;
  constructor(private route: ActivatedRoute, private roundService: RoundService, private raceService : RaceService) {
    this.viewId = 0;
    setInterval(() => {this.now = Date.now()}, 1000);
  }


  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.loadRounds();
  }

  setCurrentView(viewId: number) {
    this.viewId = viewId;
  }

  loadRounds() {
    this.roundService.getRounds().subscribe((e: EventDto) => {
      this.event = e
      console.log(e.event);
      console.log(e.event.rounds);
      this.activeRound=e.event.rounds.find(x=>x.isActive);
      console.log(this.activeRound);
    }, (error: any) => console.log(error))
  }

  loadRaces(roundId:number)
  {
    this.raceService.getRaces(roundId).subscribe(races=>{
      this.races=races;
    });
    return this.races;
  }
  timeToSign()
  {
    var duration =  (+new Date(this.activeRound.roundDay)) - (+this.now)
    console.log(duration);
    this.seconds = Math.floor((duration / 1000) % 60) | 0,
    this.minutes = Math.floor((duration / (1000 * 60)) % 60)|0,
    this.hours = Math.floor((duration / (1000 * 60 * 60)) % 24) |0;
    return this.hours + ":"+this.minutes+":"+this.seconds;
  }

}

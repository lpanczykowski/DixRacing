import { Component, Input, OnInit } from '@angular/core';
import { EventWithActiveRounds } from 'app/_models/eventWithActiveRound';
import { Round } from 'app/_models/round';

@Component({
  selector: 'app-event-box',
  templateUrl: './event-box.component.html',
  styleUrls: ['./event-box.component.css']
})
export class EventBoxComponent implements OnInit {
  @Input() raceEvent: EventWithActiveRounds;
  activeRound : Round;
  today: number = Date.now();
  indexOfActiveRound : number;

  constructor() {
    setInterval(() => {this.today = Date.now()}, 1);
}

  ngOnInit(): void {
    this.activeRound = this.raceEvent.rounds.filter(x=>x.isActive)[0];
    this.indexOfActiveRound = this.raceEvent.rounds.indexOf(this.activeRound) +1;
  }

  calculateDiff(){
    const date = new Date(); //const date = new Date(this.raceEvent.activeRound.roundDay);
    const currentDate = new Date();
    var duration =  (+date) - (+currentDate)
    var milliseconds = Math.floor((duration % 1000) / 100),
    seconds = Math.floor((duration / 1000) % 60),
    minutes = Math.floor((duration / (1000 * 60)) % 60),
    hours = Math.floor((duration / (1000 * 60 * 60)) % 24);
    return milliseconds;
  }

}

import { Component, Input, OnInit } from '@angular/core';
import { EventWithActiveRound } from 'app/_models/eventWithActiveRound';

@Component({
  selector: 'app-event-box',
  templateUrl: './event-box.component.html',
  styleUrls: ['./event-box.component.css']
})
export class EventBoxComponent implements OnInit {
  @Input() raceEvent: EventWithActiveRound;
  today: number = Date.now();

  constructor() {
    setInterval(() => {this.today = Date.now()}, 1);
}

  ngOnInit(): void {
    this.raceEvent.photo="https://www.racedepartment.com/attachments/timthumb-png.312357/";
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

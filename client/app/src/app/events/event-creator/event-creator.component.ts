import { Component, OnInit } from '@angular/core';
import { EventCreateDto, RoundCreateDto } from 'app/_models/eventCreateDto';
import { EventService } from 'app/_services/event.service';
import {ConfirmationService} from 'primeng/api';

@Component({
  selector: 'app-event-creator',
  templateUrl: './event-creator.component.html',
  styleUrls: ['./event-creator.component.css'],
})
export class EventCreatorComponent implements OnInit {
  model: EventCreateDto = new EventCreateDto();
  constructor(private eventService: EventService,
              private confirmationService: ConfirmationService
    ) {}

  ngOnInit(): void {}

  createEvent() {
    console.log(this.model);

    // this.eventService.createEvent(this.model);
  }
  selectGame(selectedGame:number){
    this.model.gameId=selectedGame;
  }
  addRound(){
    this.model.rounds.push(new RoundCreateDto());
  }
  deleteRound(round : RoundCreateDto)
  {
    this.confirmationService.confirm({
      message: 'Czy napewno chcesz usunąć rundę?',
      accept: () => {
        this.model.rounds =  this.arrayRemove(this.model.rounds, round);
      }});
  }
  arrayRemove(arr, value) {
    return arr.filter(function(ele){
        return ele != value;
    });

}
save(){
}
uploadImage(base64:string)
{
  this.model.photo = base64;
}
}

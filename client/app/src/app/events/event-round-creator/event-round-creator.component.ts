import { HttpParams } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { EventCreateDto, RaceCreateDto, RoundCreateDto } from 'app/_models/eventCreateDto';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-event-round-creator',
  templateUrl: './event-round-creator.component.html',
  styleUrls: ['./event-round-creator.component.css']
})
export class EventRoundCreatorComponent implements OnInit {

  @Input() gameEvent : EventCreateDto;
  @Input() round : RoundCreateDto;
  queryParams : HttpParams;
  constructor(private confirmationService : ConfirmationService) { }

  ngOnInit(): void {
    this.queryParams = new HttpParams().set('gameId', this.gameEvent.gameId);
  }
  selectTrack(event :any)
  {

  }
  addRace(){
    this.round.races.push(new RaceCreateDto());
  }
  deleteRace(race : RaceCreateDto){
    this.confirmationService.confirm({
      message: 'Czy napewno chcesz usunąć wyścig?',
      accept: () => {

    this.round.races =  this.arrayRemove( this.round.races, race);
      }
    });
}
  arrayRemove(arr, value) {
    return arr.filter(function(ele){
        return ele != value;
    });
}

}

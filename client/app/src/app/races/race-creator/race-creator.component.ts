import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RaceCreateDto } from 'app/_models/raceCreateDto';
import { RoundService } from 'app/_services/round.service';

@Component({
  selector: 'app-race-creator',
  templateUrl: './race-creator.component.html',
  styleUrls: ['./race-creator.component.css']
})
export class RaceCreatorComponent implements OnInit {
  model:RaceCreateDto=new RaceCreateDto;
  eventId:number;
  constructor(private route:ActivatedRoute, private roundService:RoundService) { }

  ngOnInit(): void {
    this.eventId=Number(this.route.snapshot.paramMap.get('eventId'));
  }

  createRace(){
    this.roundService.createRace(this.eventId,this.model);
  }
}

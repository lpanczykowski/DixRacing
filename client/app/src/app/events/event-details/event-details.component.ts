import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TouchSequence } from 'selenium-webdriver';
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
  rounds: Round[];
  races: Race[];
  viewId : number;
  activeRound: Round;
  eventId:number;

  constructor(private route:ActivatedRoute, private roundService:RoundService, private raceService:RaceService) {
    this.viewId = 0 ;
  }


  ngOnInit(): void {

    this.eventId=Number(this.route.snapshot.paramMap.get('eventId'));
    this.loadRounds();
  }

  setCurrentView(viewId : number)
  {
    this.viewId =  viewId;
  }

  loadRounds()
  {
    this.roundService.getRounds().subscribe(rounds=>{
      this.rounds=rounds;
      this.activeRound=rounds.find(x=>x.isActive);
    })
  }

  loadRaces(roundId:number)
  {
    this.raceService.getRaces(roundId).subscribe(races=>{
      this.races=races;
    });
    return this.races;
  }
  
}

import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TouchSequence } from 'selenium-webdriver';
import { Round } from '_models/round';
import { RoundService } from '_services/round.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {
  rounds: Round[];
  viewId : number;
  activeRound: Round;
  eventId:number;

  constructor(private route:ActivatedRoute, private roundService:RoundService) {
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
      console.log(this.activeRound);
    })
  }

}

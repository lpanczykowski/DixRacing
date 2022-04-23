import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatCardActions } from '@angular/material/card';
import { ActivatedRoute } from '@angular/router';
import { RaceResult } from '../../_models/raceResult';
import { RaceService } from '../../_services/race.service';

@Component({
  selector: 'app-race-results',
  templateUrl: './race-results.component.html',
  styleUrls: ['./race-results.component.css'],
})
export class RaceResultsComponent implements OnInit {
  @Input() resultsSelector: string;
  @Output() numberOfParticipantsEmitter = new EventEmitter<number>();

  currentResults: string;
  raceId: number;
  raceResults: RaceResult[];

  constructor(
    private route: ActivatedRoute,
    private raceService: RaceService
  ) {}

  ngOnInit(): void {
    this.raceId = Number(this.route.snapshot.paramMap.get('raceId'));
    this.loadData();
  }

  loadData() {
    this.raceService
      .getRaceResults(this.raceId, 'R')
      .subscribe((resp) => {
        this.raceResults = resp;
        console.log(this.raceResults);
        let participantCount = this.raceResults.length;
        this.numberOfRaceParticipants(participantCount);
      });
  }

  numberOfRaceParticipants(participants: number) {
    this.numberOfParticipantsEmitter.emit(participants);
  }
}

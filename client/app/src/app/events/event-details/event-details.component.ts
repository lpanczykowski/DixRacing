import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventDto } from 'app/_models/raceEvent/event';
import { Race } from 'app/_models/race';
import { Round } from 'app/_models/round';
import { AccountService } from 'app/_services/account.service';
import { EventService } from 'app/_services/event.service';
import { RaceService } from 'app/_services/race.service';
import { RoundService } from 'app/_services/round.service';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css'],
})
export class EventDetailsComponent implements OnInit {
  event: EventDto;
  viewId: number;
  activeRound: Round;
  rounds: Round[];
  eventId: number;
  races: Race[];
  now: any;
  activeItem: MenuItem;
  seconds;
  minutes;
  hours: number;
  displayBasic: boolean;
  displaySignupForm: boolean;
  isParticipant: boolean;
  crumbs:MenuItem[];
  constructor(
    private route: ActivatedRoute,
    private raceService: RaceService,
    private eventService: EventService,
    public accountService: AccountService,
  ) {
    this.viewId = 0;
    setInterval(() => {
      this.now = Date.now();
    }, 1000);
  }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.loadRounds();
    this.crumbs=[
      {label:'Strona główna',routerLink: ['/home']},
      {label:'Event ' + this.eventId,},
  ]
  }

  setCurrentView(viewId: number) {
    this.viewId = viewId;
  }

  loadRounds() {
    this.eventService.getRounds(this.eventId).subscribe(
      (e: EventDto) => {
        this.event = e;
        this.rounds = e.event.rounds;
        this.activeRound = e.event.rounds.find((x) => x.isActive);
        this.loadRaces(this.activeRound.id);
      },
      (error: any) => console.log(error)
    );
  }

  loadRaces(roundId: number) {
    this.raceService.getRaces(roundId).subscribe((races) => {
      this.races = races;
      console.log(this.races);
    });
    return this.races;
  }
  timeToSignAsString() {
    var duration = this.timeToSign();
    (this.seconds = Math.floor((duration / 1000) % 60) | 0),
      (this.minutes = Math.floor((duration / (1000 * 60)) % 60) | 0),
      (this.hours = Math.floor(duration / (1000 * 60 * 60)) | 0);
    return this.hours + ':' + this.minutes + ':' + this.seconds;
  }
  timeToSign() {
    var duration = +new Date(this.activeRound.roundDay) - +this.now;
    return duration;
  }

  showRoundCreator() {
    this.displayBasic = true;
  }

  showSignupForm() {
    this.displaySignupForm = true;
  }
}

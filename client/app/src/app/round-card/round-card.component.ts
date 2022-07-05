import { Component, Input, OnInit } from '@angular/core';
import { Race } from 'app/_models/race';
import { Round } from 'app/_models/round';

@Component({
  selector: 'app-round-card',
  templateUrl: './round-card.component.html',
  styleUrls: ['./round-card.component.css'],
})
export class RoundCardComponent implements OnInit {
  @Input() round: Round;
  @Input() races: Race;

  constructor() {}

  ngOnInit() {}
}

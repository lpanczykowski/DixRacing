
import { ActivatedRoute } from '@angular/router';
import { Round } from 'app/_models/round';
import { Race } from 'app/_models/race';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-race-box',
  templateUrl: './race-box.component.html',
  styleUrls: ['./race-box.component.css']
})
export class RaceBoxComponent implements OnInit {
 @Input() round: Round;
 @Input() race: Race;
  constructor() { }

  ngOnInit(): void {
  }

}

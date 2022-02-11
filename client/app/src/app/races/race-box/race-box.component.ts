import { Component, Input, OnInit } from '@angular/core';
import { Round } from '_models/round';
import {Race} from '_models/race';
import { ThrowStmt } from '@angular/compiler';
import { RaceService } from '_services/race.service';
import { race } from 'rxjs';

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

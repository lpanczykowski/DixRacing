import { Component, Input, OnInit } from '@angular/core';
import { ThrowStmt } from '@angular/compiler';
import { race } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Round } from 'src/app/_models/round';
import { Race } from 'src/app/_models/race';

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

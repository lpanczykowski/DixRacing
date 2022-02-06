import { Component, Input, OnInit } from '@angular/core';
import { Round } from '_models/round';

@Component({
  selector: 'app-race-box',
  templateUrl: './race-box.component.html',
  styleUrls: ['./race-box.component.css']
})
export class RaceBoxComponent implements OnInit {
 @Input() round: Round;
  constructor() { }

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';
import { UserStats } from 'app/_models/userStats';

@Component({
  selector: 'app-user-stats',
  templateUrl: './user-stats.component.html',
  styleUrls: ['./user-stats.component.css']
})
export class UserStatsComponent implements OnInit {

  userStats:UserStats={starts:125,wins:7,podiums:16,topTen:85,polePositions:2,fastestLaps:6,penaltiesPerRace:0.64};

  constructor() { }

  ngOnInit(): void {
  }

}

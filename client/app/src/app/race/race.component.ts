import { Component, OnInit } from '@angular/core';
import { Driver } from '_models/driver';
import { DriverService } from '_services/driver.service';

@Component({
  selector: 'app-race',
  templateUrl: './race.component.html',
  styleUrls: ['./race.component.css']
})
export class RaceComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
  }

}

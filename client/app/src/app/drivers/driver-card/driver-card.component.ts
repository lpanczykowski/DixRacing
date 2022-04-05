import { Component, Input, OnInit } from '@angular/core';
import { Driver } from 'app/_models/driver/driver';

@Component({
  selector: 'app-driver-card',
  templateUrl: './driver-card.component.html',
  styleUrls: ['./driver-card.component.css']
})

export class DriverCardComponent implements OnInit {
@Input() driver: Driver;

  constructor() { }

  ngOnInit(): void {
  }

}

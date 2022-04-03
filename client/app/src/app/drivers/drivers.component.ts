import { Component, OnInit } from '@angular/core';
import { $ } from 'protractor';
import { Driver } from '../_models/driver/driver';
import { DriverService } from '../_services/driver.service';

@Component({
  selector: 'app-drivers',
  templateUrl: './drivers.component.html',
  styleUrls: ['./drivers.component.css']
})
export class DriversComponent implements OnInit {
  drivers: Driver[];

  constructor(private driverService: DriverService) { }

  ngOnInit(): void {

  }

}

import { Component, OnInit } from '@angular/core';
import { Driver } from '_models/driver';
import { DriverService } from '_services/driver.service';

@Component({
  selector: 'app-driver-list',
  templateUrl: './driver-list.component.html',
  styleUrls: ['./driver-list.component.css']
})
export class DriverListComponent implements OnInit {

  drivers: Driver[];

  constructor(private driverService: DriverService) { }

  ngOnInit(): void {
    this.loadDrivers();

  }

  loadDrivers(){
    this.driverService.getDrivers().subscribe(drivers=>{
      this.drivers=drivers;
      console.log(this.drivers);
    })
  }
}

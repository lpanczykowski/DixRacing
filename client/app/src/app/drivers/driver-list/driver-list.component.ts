import { Component, OnInit } from '@angular/core';
import { Driver } from '_models/driver/driver';
import { DriverParams } from '_models/driver/driverParams';
import { PaginatedResult, Pagination } from '_models/pagination';
import { DriverService } from '_services/driver.service';

@Component({
  selector: 'app-driver-list',
  templateUrl: './driver-list.component.html',
  styleUrls: ['./driver-list.component.css']
})
export class DriverListComponent implements OnInit {

  drivers: Driver[];
  pagination : Pagination
  driverParams : DriverParams;

  constructor(private driverService: DriverService) { }

  ngOnInit(): void {
    this.driverParams = new DriverParams();
    this.loadDrivers();
  }

  loadDrivers(){

    this.driverService.getDrivers(this.driverParams).subscribe(response=>{
      this.drivers=response.rows;
      this.pagination = new Pagination(response.totalRowCount,response.totalPages,response.currentPage,response.itemsPerPage);
      console.log(this.pagination);
    })
  }

  pageChanged(event :any){
    this.driverParams.pageNumber = event.page;
    this.loadDrivers();
  }
}

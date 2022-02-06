import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {
  viewId : number
  constructor(private route:ActivatedRoute) {
    this.viewId = 0 ;
  }


  ngOnInit(): void {

    console.log(this.route.snapshot.paramMap.get('eventId'));
  }

  setCurrentView(viewId : number)
  {
    this.viewId =  viewId;
  }

}

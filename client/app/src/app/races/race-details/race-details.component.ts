import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-race-details',
  templateUrl: './race-details.component.html',
  styleUrls: ['./race-details.component.css']
})
export class RaceDetailsComponent implements OnInit {
  view:string;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.view = this.route.snapshot.paramMap.get('view');
  }

  setCurrentView(view: string) {
    this.view = view;
  }

}

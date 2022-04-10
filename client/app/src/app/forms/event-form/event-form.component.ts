import { Component, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css'],
})
export class EventFormComponent implements OnInit {
  @Input() displayModal: boolean = true;
  constructor() {}

  ngOnInit() {}
}

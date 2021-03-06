import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import { AccountService } from 'app/_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  displayEventCreator: boolean = false;
  constructor(public accountService: AccountService) { }

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    events: [
      { title: 'event 1', date: '2019-04-01' },
      { title: 'event 2', date: '2019-04-02' },
    ],
  };
  handleDateClick(arg) {
    alert('date click! ' + arg.dateStr);
  }
  onAddEventClick() {
    this.displayEventCreator = true;
  }

  ngOnInit(): void { }
}

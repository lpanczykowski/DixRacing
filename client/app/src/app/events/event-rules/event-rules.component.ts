import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from 'app/_services/account.service';
import { EventService } from 'app/_services/event.service';

@Component({
  selector: 'app-event-rules',
  templateUrl: './event-rules.component.html',
  styleUrls: ['./event-rules.component.css']
})
export class EventRulesComponent implements OnInit {
  isAdmin : boolean = false;
  edit : boolean  = false;
  eventId : number;
  @Input() htmlContent:string;

  constructor(private accountService : AccountService, private eventService :EventService,private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.accountService.currentUser$.subscribe(x=> this.isAdmin= x.roles.includes("Admin"));
  }
  saveRules()
  {
    this.eventService.updateEvent({id:this.eventId,rules:this.htmlContent}).subscribe();
    this.edit = false;
  }
  editRules()
  {
    this.edit = true;
  }
}

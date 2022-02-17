import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginUserDto } from '_models/login';
import { User } from '_models/user';
import { AccountService } from '_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: LoginUserDto;

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
    this.model = new LoginUserDto();
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
    }, error => { console.log(error); })
  }

  logout() {
    this.accountService.logout();
  }
  connectSteam() {
    this.accountService.steam();
  }
}

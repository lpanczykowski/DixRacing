import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api/menuitem';
import { Observable } from 'rxjs';
import { LoginUserDto } from '../_models/login';

import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: LoginUserDto;
  items: MenuItem[] = [
    {
      label: 'Profil',
      icon: 'pi pi-user',
    },
    {
      label: 'Wyloguj',
      icon: 'pi pi-fw pi-power-off',
      command: () => {
        this.logout();
      },
    },
  ];

  constructor(public accountService: AccountService) {}

  ngOnInit(): void {
    this.model = new LoginUserDto();
  }

  login() {
    this.accountService.login(this.model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  logout() {
    this.accountService.logout();
  }
  connectSteam(userId: number) {
    this.accountService.steam(userId);
  }
}

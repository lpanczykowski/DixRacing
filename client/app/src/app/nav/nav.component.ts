import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api/menuitem';
import { Observable } from 'rxjs';
import { LoginUserDto } from '../_models/login';
import { Router } from '@angular/router';
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
      command: () => {
        this.driverProfile();
      },
    },
    {
      label: 'Wyloguj',
      icon: 'pi pi-fw pi-power-off',
      command: () => {
        this.logout();
      },
    },
  ];

  constructor(public accountService: AccountService, private router: Router) {}

  ngOnInit(): void {
    this.model = new LoginUserDto();
  }

  login() {
    this.accountService.steam();
  }

  logout() {
    this.accountService.logout();
  }
  connectSteam(userId: number) {
    this.accountService.steam();
  }

  driverProfile() {
    this.router.navigate(['/profile']);
  }
}

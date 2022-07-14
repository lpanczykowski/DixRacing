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
  menuItems: MenuItem[];
  constructor(public accountService: AccountService, private router: Router) {}

  ngOnInit(): void {
    if (!this.menuItems)
      this.createMenu();
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
  openAdminPanel()
  {
    this.router.navigate(['/admin/panel']);
  }
  driverProfile() {
    this.accountService.currentUser$.subscribe(x=>
      this.router.navigate(['/profile/' + this.accountService.getDecodedToken(x.token).unique_name ])
      )
  }
  createMenu()
  {
    this.menuItems = [];
    this.menuItems.push( {
      label: 'Profil',
      icon: 'pi pi-user',
      command: () => {
        this.driverProfile();
      },
    });
    this.menuItems.push({
      label: 'Wyloguj',
      icon: 'pi pi-fw pi-power-off',
      command: () => {
        this.logout();
      },
    });

    this.menuItems.push( {
      label: 'Panel admina',
      icon: 'pi pi-fw pi-flag',
      command: () => {
        this.openAdminPanel();
      },
      visible : true
    });
  }
}

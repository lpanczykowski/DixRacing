import { AccountService } from './../_services/account.service';
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';

import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { User } from 'app/_models/user';
@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  user: User;

  constructor(private authService: AccountService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return this.authService.currentUser$.pipe(
      map((user) => {
        if (user) return true;
        this.router.navigate(['']);
        return false;
      })
    );
  }
}

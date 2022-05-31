import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from 'environments/environment';
import { User } from '../_models/user';
import { RegisterUserDto } from 'app/_models/registerUserDto';
import { UserDto } from 'app/_models/userDto';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json-patch+json' }),
};

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  private admin = new ReplaySubject<Boolean>(1);
  currentUser$ = this.currentUserSource.asObservable();
  admin$ = this.admin.asObservable();
  constructor(private http: HttpClient) { }

  login(user: User) {
    if (user) {
      localStorage.setItem('user', JSON.stringify(user));
      this.currentUserSource.next(user);
    }
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  getCredentials() {
    return this.http.get(this.baseUrl + 'account/credentials').pipe(
      map((x: boolean) => {
        this.admin.next(x);
      })
    )
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.admin.next(null);
  }

  register(registerUserDto: RegisterUserDto) {
    return this.http
      .post(
        this.baseUrl + 'account/register',
        JSON.stringify({ registerUserDto }),
        httpOptions
      )
      .pipe(
        map((user: User) => {
          if (user) {
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUserSource.next(user);
          }
        })
      );
  }
  steam() {
    window.location.href = 'https://localhost:5001/api/steam/login';
  }

  getUserInfo() { }

  changeUserInfo(userDto: UserDto) { }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators'
import { environment } from 'src/environments/environment';
import { RegisterUserDto } from '_models/registerUserDto';
import { User } from '_models/user';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json-patch+json'})
};


@Injectable({
  providedIn: 'root'
})

export class AccountService {
  baseUrl=environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();



  constructor(private http: HttpClient) { }


  login(model: any)
  {
    return this.http.post(this.baseUrl+'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user:User)
  {
    this.currentUserSource.next(user);
  }

  logout()
  {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  register(registerUserDto: any)
  {
    return this.http.post(this.baseUrl+'account/register',JSON.stringify({registerUserDto}),httpOptions).pipe(
      map((user: User) =>{
        if(user)
        {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }
  steam(userId : number)
  {
    window.location.href  = this.baseUrl+"steam/login/"+userId  ;
  }
}

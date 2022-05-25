import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'app/_services/account.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  steamId: string = ""
  constructor(private route: ActivatedRoute, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.steamId = this.route.snapshot.paramMap.get('steamId');
    this.route.queryParams.subscribe(params => {
      let token = params["token"]
      if (token) {
        this.accountService.login({ discord: '', email: '', name: '', nick: '', shortcut: '', steamId: this.steamId, surname: '', token: token, userId: 1 })
        this.router.navigate([], { queryParams: {} });
      }
      console.log(token);
    })
    this.accountService.getCredentials().subscribe(x => { console.log(x) });
  }

}

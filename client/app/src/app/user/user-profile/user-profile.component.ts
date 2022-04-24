import { Component, OnInit } from '@angular/core';
import { User } from 'app/_models/user';
import { UserDto } from 'app/_models/userDto';
import { AccountService } from 'app/_services/account.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  user:User={name:'Marcin',surname:'Lewandowski',nick:'fevio',email:'fevio@fevio.pl',steamId:'7986541651684',token:'tokenNormlanie',userId:123};
  model:UserDto=new UserDto();
  disabled: boolean = true;

  constructor(private accountService:AccountService) { }

  ngOnInit(): void {
    // this.accountService.getUserInfo();

  }

  showEditableDisplay(){
    this.disabled=false;
  }

  hideEditableDisplay(){
    this.disabled=true;
  }

  saveEditedData(){
    console.log(this.model)
    this.accountService.changeUserInfo(this.model);
    this.disabled=true;

  }
}

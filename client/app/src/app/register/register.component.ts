import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterUserDto } from '_models/registerUserDto';
import { AccountService } from '_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: RegisterUserDto=new RegisterUserDto();
  registerMode=false;

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  register()
  {
    this.accountService.register(this.model).subscribe(response => {
      this.router.navigateByUrl('/home');
      this.cancel();
    },error=>{error.log(error);}
    )
  }

  cancel()
  {
    this.cancelRegister.emit(false);
  }

  registerToggle()
  {
    this.registerMode=!this.registerMode;
  }

  cancelRegisterMode(event:boolean)
  {
    this.registerMode=event;
  }
}

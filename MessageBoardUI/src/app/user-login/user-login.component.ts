import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from '../login';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  constructor(private loginService : LoginService, private router: Router) { }

  ngOnInit(): void {
  }

  userlogin(username, password) : void {
    this.loginService
      .login(username, password)
      .subscribe(
        data => {
          if (data == false) {
            this.router.navigate([""]);
          }
          else {
            this.router.navigate(['/messages']);
          }
        }
      );
  }
}

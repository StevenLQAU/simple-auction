import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LoginService } from '../login.service';
import { JwtUserModel } from '../models';

@Component({
  selector: 'app-login-main',
  templateUrl: './login-main.component.html',
  styleUrls: ['./login-main.component.css']
})
export class LoginMainComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  private loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  ngOnInit() {

  }

  onSubmit() {
    const username = this.loginForm.value.username;
    this.loginService
      .login(this.loginForm.value.username, this.loginForm.value.password)
      .subscribe((result: JwtUserModel) => {
        localStorage.setItem('jwt_token', result.token);
        localStorage.setItem('username', username);
        localStorage.setItem('jwt_token_expire_at', JSON.stringify(result.expireAt.valueOf()));
      }, () => {

      });
  }
  isLoggedIn() {
    return this.loginService.isLoggedIn();
  }

  getUsername() {
    return localStorage.getItem('username');
  }

  logout() {
    this.loginService.logout();
  }
}


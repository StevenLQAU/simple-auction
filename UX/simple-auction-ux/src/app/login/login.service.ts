import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from '../../../node_modules/rxjs';
import { LoginModel } from './models';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  public username: string;
  constructor(private httpClient: HttpClient, ) { }

  public login(username: string, password: string): Observable<Object> {
    const url = environment.apiUrl + 'Auth';
    return this.httpClient.post(url, new LoginModel(username, password));
  }

  public isLoggedIn() {
    return moment().isBefore(this.getExpiration());
  }

  getExpiration() {
    const expiration = localStorage.getItem('jwt_token_expire_at');
    const expiresAt = JSON.parse(expiration);
    return moment(expiresAt);
  }

  logout() {
    localStorage.removeItem('jwt_token');
    localStorage.removeItem('jwt_token_expire_at');
  }
}



export class LoginModel {
  Username: string;
  Password: string;
  constructor(username: string, password: string) {
    this.Username = username;
    this.Password = password;
  }
}

export interface JwtUserModel {
  token: string;
  userId: string;
  expireAt: Date;
}

import { Component, OnInit } from '@angular/core';
import { GoogleLoginProvider, AuthService } from 'angular-6-social-login';

import { GoogleAuthService } from '../shared/services/auth-service';
import { User } from '../shared/models/user-model';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styles: [
  ]
})

export class AuthComponent implements OnInit {

  response;
  users = new User();
  constructor(
    public OAuth: AuthService,
    public GAuthService: GoogleAuthService
  ) { }
  ngOnInit() {

  }

  public socialSignIn(socialProvider: string) {
    let socialPlatformProvider;
    if (socialProvider === 'google') {
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    }

    this.OAuth.signIn(socialPlatformProvider).then(users => {
      console.log(socialProvider, users);
      console.log(users);
      this.Savesresponse(users);
    });
  }

  Savesresponse(users: User) {
    this.GAuthService.AuthUser(users).subscribe((res: any) => {
      debugger;
      console.log(res);
      this.users = res;
      this.response = res.userDetail;
      localStorage.setItem('socialusers', JSON.stringify(this.users));
      console.log(localStorage.setItem('socialusers', JSON.stringify(this.users)));
      console.log(localStorage.getItem('socialusers'));
    })
  }

  isUserAuthenticated() {
    let token = (localStorage.getItem('socialusers'));
    if (token)
      return true;
    else return false;
  }

  logOut() {
    localStorage.clear();
  }
}
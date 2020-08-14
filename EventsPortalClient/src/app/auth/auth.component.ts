import { Component, OnInit } from '@angular/core';
import { GoogleLoginProvider, AuthService } from 'angular-6-social-login';
import { AuthenticateService } from '../shared/services/auth-service';
import { User } from '../shared/models/user-model';
import { AuthGuard } from '../shared/config/auth-provider';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styles: [
  ]
})

export class AuthComponent implements OnInit {
  token = JSON.parse(localStorage.getItem('socialusers'));
  userName: string;
  response;
  users = new User();

  constructor(
    public oAuth: AuthService,
    public authService: AuthenticateService,
    public authGuard: AuthGuard,
    private router: Router
  ) { }

  ngOnInit() {
    this.userName = this.token.UserName;
  }

  socialSignIn(socialProvider: string) {
    let socialPlatformProvider;
    if (socialProvider === 'google') {
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    }
    this.oAuth.signIn(socialPlatformProvider).then(users => {
      this.savesresponse(users);
    });
  }

  savesresponse(users: User) {
    this.authService.AuthUser(users).subscribe((res: any) => {
      this.users = res;
      this.response = res.userDetail;
      localStorage.setItem('socialusers', JSON.stringify(this.users));
      this.router.navigate(["/allowed-event-list"]);
    })
  }

  logOut() {
    localStorage.clear();
    this.authService.SignOut().subscribe((res: any)=>{});
  }
}

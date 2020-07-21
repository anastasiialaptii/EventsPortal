import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Cookie } from 'ng2-cookies/ng2-cookies';
import { decode } from 'punycode';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: []
})
export class HomeComponent {
  constructor(private jwtHelper: JwtHelperService, private router: Router
  ) { }  

  isUserAuthenticated() {
    let token = Cookie.get('Token');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
     console.log(decode(token));
      return true;
    }
    else {
      return false;
    }
  }

  public logOut = () => {
    Cookie.delete('Token');
  }

  public socialSignIn(){

  }
}

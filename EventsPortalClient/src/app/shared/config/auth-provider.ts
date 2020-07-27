import { AuthServiceConfig, GoogleLoginProvider } from "angular-6-social-login";
import { Configuration } from './configuration'
import { Injectable } from '@angular/core';
import { CanActivate } from "@angular/router";

export function getAuthServiceConfigs() {
  let config = new AuthServiceConfig(
    [
      {
        id: GoogleLoginProvider.PROVIDER_ID,
        provider: new GoogleLoginProvider(Configuration.GoogleProvider)
      }
    ]
  );
  return config;
}

@Injectable()
export class AuthGuard implements CanActivate {

  constructor() { }

  canActivate() {
    let token = (localStorage.getItem('socialusers'));
    if (token) {
      console.log("token exists");
      return true;
    }
    return false;
  }
}

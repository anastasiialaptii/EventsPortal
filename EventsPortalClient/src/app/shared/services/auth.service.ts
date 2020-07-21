import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Configuration } from 'app/appsettings/config';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Cookie } from 'ng2-cookies/ng2-cookies';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    formData: User;
    invalidLogin: boolean;

    constructor(private router: Router, public http: HttpClient) { }
  
    AuthUser() {
      return this.http.post('http://localhost:50618/signin-google', this.formData)
    }

}

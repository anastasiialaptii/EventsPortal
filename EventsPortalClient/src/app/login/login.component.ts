import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';
import { Cookie } from 'ng2-cookies/ng2-cookies';

@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  invalidLogin: boolean;

  constructor(private router: Router, private http: HttpClient) { }

  public login = (form: NgForm) => {
    const credentials = JSON.stringify(form.value);
    this.http.post("http://localhost:50618/api/User/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      const token = (<any>response).Token;
     // console.log(response);
     // console.log(token);
     // localStorage.setItem('Token', token);
      
      Cookie.set('Token', token);
      this.invalidLogin = false;
      this.router.navigate(["/"]);
    }, err => {
      this.invalidLogin = true;
    });
  }
}

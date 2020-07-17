import { Injectable } from '@angular/core';
import { User } from './user.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  formData: User;
  readonly rootURL = 'http://localhost:50618/api';


  constructor(public http: HttpClient) { }

  CreateUser() {
    return this.http.post(this.rootURL + '/User/CreateUser', this.formData)
  }

  GetUserList() {
    return this.http.get(this.rootURL + '/User/GetUsersList')
  }
}
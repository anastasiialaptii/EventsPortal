import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  formData: User;
  userList: User[];
  readonly rootURL = 'http://localhost:50618/api';


  constructor(public http: HttpClient) { }

  CreateUser() {
    return this.http.post(this.rootURL + '/User/CreateUser', this.formData)
  }

  GetUserList() {
    this.http.get(this.rootURL + '/User/GetUsersList')
      .toPromise()
      .then(res => this.userList = res as User[]);
  }
}
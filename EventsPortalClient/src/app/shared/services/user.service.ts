import { HttpClient } from '@angular/common/http';
import { Configuration } from 'app/appsettings/config';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})

export class UserService {
    formData: User;
  
    constructor(public http: HttpClient) { }
  
    CreateUser() {
      return this.http.post(Configuration.rootURL + '/User/CreateUser', this.formData)
    }
  
    DeleteUser(id) {
      return this.http.delete(Configuration.rootURL + '/User/DeleteUser/' + id)
    }

    UpdateUser(id){
        return this.http.put(Configuration.rootURL+ '/User/UpdateUser/' + id, this.formData)
    }
  }
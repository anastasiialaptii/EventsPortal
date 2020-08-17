import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRoute } from '../config/BaseRoute';

@Injectable({
    providedIn: 'root'
})

export class AuthenticateService {

    constructor(private http: HttpClient) { }

    AuthUser(responce) {
        return this.http.post(BaseRoute.Auth + '/GoogleAuth', responce, { withCredentials: true });
    }

    SignOut() {
        return this.http.get(BaseRoute.Auth + '/SignOut');
    }
}

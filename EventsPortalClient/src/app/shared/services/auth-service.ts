import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../config/configuration';

@Injectable({
    providedIn: 'root'
})

export class AuthenticateService {

    constructor(private http: HttpClient) { }

    AuthUser(responce) {

        return this.http.post(Configuration.URI + '/Auth/GoogleAuth', responce, { withCredentials: true });
    }

    SignOut() {
        return this.http.get(Configuration.URI + '/Auth/SignOut');
    }
}

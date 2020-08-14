import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../config/configuration';

@Injectable({
    providedIn: 'root'
})

export class GoogleAuthService {

    constructor(private http: HttpClient) { }

    AuthUser(responce) {

        return this.http.post(Configuration.URI + '/Auth/Savesresponse', responce, { withCredentials: true });
    }

    AuthCookie() {
        return this.http.get(Configuration.URI + '/Auth/Authenticate');
    }

    SignOut() {
        return this.http.get(Configuration.URI + '/Auth/SignOut');
    }
}

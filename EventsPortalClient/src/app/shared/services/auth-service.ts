import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Configuration } from '../config/configuration';

@Injectable({
    providedIn: 'root'
})

export class GoogleAuthService {
    url: string;

    constructor(private http: HttpClient) { }
    AuthUser(responce) {
        this.url = Configuration.URI + '/Auth/Savesresponse';
        return this.http.post(this.url, responce);
    }
}

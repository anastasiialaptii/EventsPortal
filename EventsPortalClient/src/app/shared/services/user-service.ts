import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Configuration } from '../config/configuration';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
    providedIn: 'root'
})

export class UserService {
    constructor(private http: HttpClient) { }

    GetUserByToken(token: string): Observable<number> {
        return this.http.get<number>(Configuration.URI + '/User/GetUserByToken/' + token);
    }
}

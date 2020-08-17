import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRoute } from '../config/BaseRoute';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
    providedIn: 'root'
})

export class UserService {
    
    constructor(private http: HttpClient) { }

    GetUserByToken(token: string): Observable<number> {
        return this.http.get<number>(BaseRoute.User + '/GetUserByToken/' + token);
    }
}

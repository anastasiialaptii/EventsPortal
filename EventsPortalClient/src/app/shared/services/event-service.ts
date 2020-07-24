import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Configuration } from '../config/configuration';
import { User } from '../models/user-model';

@Injectable({
    providedIn: 'root'
})

export class EventService {
    url: string;
    userToken: string;
    formData: Event;
    PublicEventList: Event[];
    PrivateEventList: Event[];


    constructor(private http: HttpClient) { }

    GetPublicEventList() {
        return this.http.get(Configuration.URI + '/Event/GetPublicEventList')
            .toPromise()
            .then(res => this.PublicEventList = res as Event[]);
    }

    GetPrivateEventList(id:string) {
        return this.http.get(Configuration.URI + '/Event/GetPrivateEventList/' + id)
            .toPromise()
            .then(res => this.PrivateEventList = res as Event[]);
    }

    GetEventById(id: number) {
        return this.http.get(Configuration.URI + '/Event/GetEventById/' + id);
    }
}
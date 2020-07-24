import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Configuration } from '../config/configuration';

@Injectable({
    providedIn: 'root'
})

export class EventService {
    url: string;
    formData: Event;
    PublicEventList: Event[];


    constructor(private http: HttpClient) { }

    GetPublicEventList() {
        return this.http.get(Configuration.URI + '/Event/GetPublicEventList')
            .toPromise()
            .then(res => this.PublicEventList = res as Event[]);
    }

    GetEventById(id: number) {
        return this.http.get(Configuration.URI + '/Event/GetEventById/' + id);
    }
}
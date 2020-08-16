import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../config/configuration';
import { Visit } from '../models/visit-model';

@Injectable({
    providedIn: 'root'
})

export class VisitService {
    constructor(private http: HttpClient) { }

    CreateVisit(visit: Visit) {
        return this.http.post(Configuration.URI + '/Visit/CreateVisit', visit);
    }

    GetVisitorsPerEvent(eventId: number) {
        return this.http.get(Configuration.URI + '/Visit/GetVisitorsPerEvent/' + eventId);
    }

    GetEnrollEvents() {
        return this.http.get(Configuration.URI + '/Visit/GetEnrollEvents');
    }
}

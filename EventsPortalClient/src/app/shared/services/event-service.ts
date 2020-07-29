import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Configuration } from '../config/configuration';
import { EventItem } from '../models/event-model';

@Injectable({
    providedIn: 'root'
})

export class EventService {
    formData: EventItem;
    AllowedEventList: EventItem[];
    PrivateEventList: EventItem[];

    constructor(private http: HttpClient) { }

    GetAllowedEventList() {
        return this.http.get(Configuration.URI + '/Event/GetAllowedEventList');
    }

    GetPrivateEventList(id: string) {
        return this.http.get(Configuration.URI + '/Event/GetPrivateEventList/' + id)
            .toPromise()
            .then(res => this.PrivateEventList = res as EventItem[]);
    }

    GetEventById(id: number) {
        return this.http.get(Configuration.URI + '/Event/GetEventById/' + id);
    }

    CreateEvent() {
        return this.http.post(Configuration.URI + '/Event/CreateEvent', this.formData);
    }

    DeleteEvent(id: number) {
        return this.http.delete(Configuration.URI + '/Event/DeleteEvent/' + id);
    }

    EditEvent(id: number, event: EventItem) {
        return this.http.put(Configuration.URI + '/Event/UpdateEvent/' + id, event);

    }
}

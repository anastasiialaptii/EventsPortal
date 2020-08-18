import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRoute } from '../config/BaseRoute';
import { EventItem } from '../models/event-model';

@Injectable({
    providedIn: 'root'
})

export class EventService {
    FormData: EventItem;
    SearchEventFormData: EventItem;

    constructor(private http: HttpClient) { }

    GetPublicEvents() {
        return this.http.get(BaseRoute.Events + '/GetPublicEvents');
    }

    GetPublicOwnEvents() {
        return this.http.get(BaseRoute.Events + '/GetPublicOwnEvents');
    }

    GetEvent(id: number) {
        return this.http.get(BaseRoute.Events + '/GetEvent/' + id);
    }

    CreateEvent() {
        return this.http.post(BaseRoute.Events + '/CreateEvent', this.FormData, { reportProgress: true, observe: 'events' });
    }

    DeleteEvent(id: number, idUser: string) {
        return this.http.delete(BaseRoute.Events + '/DeleteEvent/' + id + '/' + idUser);
    }

    EditEvent(id: number, event: EventItem) {
        return this.http.put(BaseRoute.Events + '/UpdateEvent/' + id, event);
    }

    SearchEvents(eventName: string) {
        return this.http.get(BaseRoute.Events + '/SearchEvents/' + eventName);
    }
}

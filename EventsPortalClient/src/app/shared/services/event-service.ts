import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../config/configuration';
import { EventItem } from '../models/event-model';

@Injectable({
    providedIn: 'root'
})

export class EventService {
    FormData: EventItem;

    SearchEventFormData: EventItem;
    SearchEventList: EventItem[];
    EventByIdList: EventItem[];
    AllowedToVisitEvent: number[];

    constructor(private http: HttpClient) { }

    GetPublicEvents() {
        return this.http.get(Configuration.URI + '/Event/GetPublicEvents');
    }

    GetPublicOwnEvents() {
        return this.http.get(Configuration.URI + '/Event/GetPublicOwnEvents');
    }

    SearchEvents(eventName: string) {
        return this.http.get(Configuration.URI + '/Event/SearchEvents/' + eventName);
    }

    CreateEvent() {
        return this.http.post(Configuration.URI + '/Event/CreateEvent', this.FormData, { reportProgress: true, observe: 'events', withCredentials: true });
    }

    GetAllowedToVisitEvent(idUser?: string) {
        return this.http.get(Configuration.URI + '/Event/GetAllowedEventToVisitList/' + idUser);
    }

    GetEvent(id: number) {
        return this.http.get(Configuration.URI + '/Event/GetEvent/' + id);
    }

    DeleteEvent(id: number, idUser: string) {
        return this.http.delete(Configuration.URI + '/Event/DeleteEvent/' + id + '/' + idUser);
    }

    EditEvent(id: number, event: EventItem) {
        return this.http.put(Configuration.URI + '/Event/UpdateEvent/' + id, event);
    }
}

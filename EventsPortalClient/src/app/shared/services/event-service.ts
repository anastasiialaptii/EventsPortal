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
    EventDate:Date;

    constructor(private http: HttpClient) { }

    CreateEvent() {
        return this.http.post(Configuration.URI + '/Event/CreateEvent', this.FormData, { reportProgress: true, observe: 'events' });
    }

    GetAllowedEventList(idUser?: string, searchString?: string) {
        if (idUser != null && searchString == null) {
            return this.http.get(Configuration.URI + '/Event/GetAllowedEventList/' + idUser);
        }
        else if (idUser != null && searchString != null) {
            return this.http.get(Configuration.URI + '/Event/GetAllowedEventList/' + idUser + '/' + searchString);
        }
    }

    GetEventListByDate(date: number) {
        return this.http.get(Configuration.URI + '/Event/GetEventsByDate/' + date);
    }

    GetEventList() {
        return this.http.get(Configuration.URI + '/Event/GetAllowedEventList');
    }

    GetAllowedToVisitEvent(idUser?: string) {
        return this.http.get(Configuration.URI + '/Event/GetAlloweEventToVisitList/' + idUser)
            .toPromise()
            .then(res => this.AllowedToVisitEvent = res as number[]);
    }

    GetEventById(id: number) {
        return this.http.get(Configuration.URI + '/Event/GetEventById/' + id)
            .toPromise()
            .then(res => this.EventByIdList = res as EventItem[]);
    }

    DeleteEvent(id: number) {
        return this.http.delete(Configuration.URI + '/Event/DeleteEvent/' + id);
    }

    EditEvent(id: number, event: EventItem) {
        return this.http.put(Configuration.URI + '/Event/UpdateEvent/' + id, event);
    }
}

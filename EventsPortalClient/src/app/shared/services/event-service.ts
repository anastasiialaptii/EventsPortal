import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Configuration } from '../config/configuration';
import { EventItem } from '../models/event-model';

@Injectable({
    providedIn: 'root'
})

export class EventService {
    formData: EventItem;
    searchEventFormData: EventItem;
    SearchEventList: EventItem[];
    EventById: EventItem;
    image: any;
    imageSrc: any;

    constructor(private http: HttpClient) { }

    getData() {
        return this.http.get(Configuration.URI + '/Event/Get');      
    }

    GetAllowedEventList(idUser: string) {
        return this.http.get(Configuration.URI + '/Event/GetAllowedEventList/' + idUser);
    }

    GetSearchedEventList() {
        return this.http.get(Configuration.URI + '/Event/GetSearchedEventList/' + this.searchEventFormData.Name)
            .toPromise()
            .then(res => this.SearchEventList = res as EventItem[]);
    }

    GetPrivateEventList(id: string) {
        return this.http.get(Configuration.URI + '/Event/GetPrivateEventList/');
    }

    GetEventById(id: number) {
        return this.http.get(Configuration.URI + '/Event/GetEventById/' + id)
            .toPromise()
            .then(res => this.EventById = res as EventItem);
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

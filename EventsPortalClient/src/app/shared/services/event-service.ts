import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';

import { Configuration } from '../config/configuration';
import { EventItem } from '../models/event-model';

@Injectable({
    providedIn: 'root'
})

export class EventService {
    image: any; //download img
    imageSrc: any; //download img
    formData: EventItem;
    searchEventFormData: EventItem;
    SearchEventList: EventItem[];
    EventById: EventItem;

    constructor(private http: HttpClient) { }

    CreateEvent() {
        return this.http.post(Configuration.URI + '/Event/CreateEvent', this.formData, { reportProgress: true, observe: 'events' });
    }

    GetAllowedEventList(idUser?: string, searchString?: string) {
        if (idUser == null && searchString == null) {
            return this.http.get(Configuration.URI + '/Event/GetAllowedEventList');
        }
        else if (idUser != null && searchString == null) {
            return this.http.get(Configuration.URI + '/Event/GetAllowedEventList/' + idUser);
        }
        else if (idUser != null && searchString != null) {
            return this.http.get(Configuration.URI + '/Event/GetAllowedEventList/' + idUser + '/' + searchString);
        }
    }

    //getting image from db 
    getData() {
        return this.http.get(Configuration.URI + '/Event/Get');
    }

    // GetSearchedEventList() {
    //     return this.http.get(Configuration.URI + '/Event/GetSearchedEventList/' + this.searchEventFormData.Name)
    //         .toPromise()
    //         .then(res => this.SearchEventList = res as EventItem[]);
    // }

    GetEventById(id: number) {
        return this.http.get(Configuration.URI + '/Event/GetEventById/' + id)
            .toPromise()
            .then(res => this.EventById = res as EventItem);
    }

    DeleteEvent(id: number) {
        return this.http.delete(Configuration.URI + '/Event/DeleteEvent/' + id);
    }

    EditEvent(id: number, event: EventItem) {
        return this.http.put(Configuration.URI + '/Event/UpdateEvent/' + id, event);
    }
}

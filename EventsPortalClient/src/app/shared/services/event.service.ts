import { HttpClient } from '@angular/common/http';
import { Configuration } from 'app/appsettings/config';
import { Injectable } from '@angular/core';
import { Events } from '../models/events.model';

@Injectable({
  providedIn: 'root'
})

export class EventService {
    formData: Events;
    AvailableEvents: Event[];
    PtivateEvents: Event[];
  
    constructor(public http: HttpClient) { }
  
    CreateEvent() {
      return this.http.post(Configuration.rootURL + '/Event/CreateEvent', this.formData)
    }
  
    DeleteEvent(id) {
      return this.http.delete(Configuration.rootURL + '/Event/DeleteEvent/' + id)
    }

    UpdateEvent(id){
        return this.http.put(Configuration.rootURL+ '/Event/UpdateEvent/' + id, this.formData)
    }
  
    GetAvailableEvents() {
      this.http.get(Configuration.rootURL + '/Event/GetEventsList')
        .toPromise()
        .then(res => this.AvailableEvents = res as Event[]);
    }
  }
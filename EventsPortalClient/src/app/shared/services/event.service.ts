import { HttpClient } from '@angular/common/http';
import { Configuration } from 'app/appsettings/config';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class EventService {
    formData: Event;
    AvailableEvents: Event[];
    PtivateEvents: Event[];
  
    constructor(public http: HttpClient) { }
  
    CreateEvent() {
      return this.http.post(Configuration.rootURL + '/Bicycles/PostBicycle', this.formData)
    }
  
    DeleteEvent(id) {
      return this.http.delete(Configuration.rootURL + '/Bicycles/DeleteBicycle/' + id)
    }

    UpdateEvent(id){
        return this.http.put(Configuration.rootURL+ '/Bicycles/DeleteBicycle/' + id, this.formData)
    }
  
    GetAvailableEvents() {
      this.http.get(Configuration.rootURL + '/Event/GetEventsList')
        .toPromise()
        .then(res => this.AvailableEvents = res as Event[]);
    }

    // GetPrivateEvents() {
    //     this.http.get(this.rootURL + '/Bicycles/GetFreeBicycles')
    //       .toPromise()
    //       .then(res => this.AvailableBicycles = res as Bicycle[]);
    //   }
  }
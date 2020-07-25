import { Component, OnInit } from '@angular/core';

import { EventService } from '../shared/services/event-service';
import { User } from '../shared/models/user-model';

@Component({
  selector: 'app-private-event-list',
  templateUrl: './private-event-list.component.html',
  styles: [
  ]
})
export class PrivateEventListComponent implements OnInit {

users:User;
  constructor(public eventService: EventService) { 
   
  }

  ngOnInit(): void {
    let x = JSON.parse(localStorage.getItem('socialusers'));
    // alert(x.Message);
    this.eventService.GetPrivateEventList(x.Message);
  }

}

import { Component, OnInit } from '@angular/core';

import { EventService } from '../shared/services/event-service';

//import { isUserAuthenticated } from '../shared/config/auth-provider';

@Component({
  selector: 'app-public-event-list',
  templateUrl: './public-event-list.component.html',
  styles: [
  ]
})
export class PublicEventListComponent implements OnInit {
isValid :any;
  constructor(public eventService: EventService) { }

  ngOnInit(): void {
    this.eventService.GetPublicEventList();
   // this.isValid = isUserAuthenticated();
  }
}

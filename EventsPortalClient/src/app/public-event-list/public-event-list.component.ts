import { Component, OnInit } from '@angular/core';

import { EventService } from '../shared/services/event-service';

@Component({
  selector: 'app-public-event-list',
  templateUrl: './public-event-list.component.html',
  styles: [
  ]
})
export class PublicEventListComponent implements OnInit {

  constructor(public eventService: EventService) { }

  ngOnInit(): void {
    this.eventService.GetPublicEventList();
  }
}

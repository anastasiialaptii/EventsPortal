import { Component, OnInit } from '@angular/core';
import { EventService } from 'app/shared/services/event.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html'
})
export class EventListComponent implements OnInit {

  constructor(public eventService: EventService) { }

  ngOnInit() {
    this.eventService.GetAvailableEvents();
  }

}

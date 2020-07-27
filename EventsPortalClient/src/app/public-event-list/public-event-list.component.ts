import { Component, OnInit } from '@angular/core';

import { EventService } from '../shared/services/event-service';
import { VisitService } from '../shared/services/visit-service';
import { Visit } from '../shared/models/visit-model';

@Component({
  selector: 'app-public-event-list',
  templateUrl: './public-event-list.component.html',
  styles: [
  ]
})

export class PublicEventListComponent implements OnInit {
  visit: Visit;
  constructor(
    public eventService: EventService,
    public visitService: VisitService) { }

  ngOnInit(): void {
    this.eventService.GetPublicEventList();
    this.visit = 
      { EventId: 83, UserId: 9  }
    ;
  }

  createEvent() {
    this.visitService.CreateVisit(this.visit).subscribe(
      res => { console.log("success") },
      err => {
        debugger;
        console.log(err);
      });
  }
}

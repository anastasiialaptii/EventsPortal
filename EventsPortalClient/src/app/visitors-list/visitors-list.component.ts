import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

import { Configuration } from '../shared/config/configuration'

import { VisitService } from '../shared/services/visit-service';
import { EventService } from '../shared/services/event-service';

import { EventItem } from '../shared/models/event-model';

@Component({
  selector: 'app-visitors-list',
  templateUrl: './visitors-list.component.html',
  styles: [
  ]
})

export class VisitorsListComponent implements OnInit {
  private subscription: Subscription;
  id: number;
  eventView: EventItem = new EventItem();
  tableMode: boolean = true;

  constructor(
    public activateRoute: ActivatedRoute,
    public visitService: VisitService,
    public eventService: EventService,
    public config: Configuration
  ) {
    this.subscription = activateRoute.params.subscribe(params => this.id = +params['eventId']);
  }

  ngOnInit(): void {
    this.visitService.GetVisitorsList(this.id);
    this.eventService.GetEventById(this.id);
  }

  editEvent(eventItem: EventItem) {
    this.tableMode = false;
    this.eventView = eventItem;
    debugger;
    console.log(this.eventView);
  }

  cancel() {
    this.eventView = new EventItem();
    this.tableMode = true;
  }

  save() {
    this.eventService.EditEvent(this.eventView.Id, this.eventView).subscribe(res=>{});
    this.tableMode = true;
  }
}

import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

import { VisitService } from '../shared/services/visit-service';
import { EventService } from '../shared/services/event-service';

@Component({
  selector: 'app-visitors-list',
  templateUrl: './visitors-list.component.html',
  styles: [
  ]
})

export class VisitorsListComponent implements OnInit {
  id: number;
  private subscription: Subscription;

  constructor(
    public activateRoute: ActivatedRoute,
    public visitService: VisitService,
    public eventService: EventService
  ) {
    this.subscription = activateRoute.params.subscribe(params => this.id = +params['eventId']);
  }

  ngOnInit(): void {
    this.visitService.GetVisitorsList(this.id);
    this.eventService.GetEventById(this.id);
  }

  public createImgPath = (serverPath: string) => {
    return `http://localhost:50618/${serverPath}`;
  }
}

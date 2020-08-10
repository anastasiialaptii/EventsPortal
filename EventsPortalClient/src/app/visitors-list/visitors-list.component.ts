import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

import { Configuration } from '../shared/config/configuration'

import { VisitService } from '../shared/services/visit-service';
import { EventService } from '../shared/services/event-service';

import { EventItem } from '../shared/models/event-model';
import { Visit } from '../shared/models/visit-model';
import { ToastrService } from 'ngx-toastr';

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
  isVisitorsExists: boolean = false;
  pageOfItemsEvent: Array<Visit>;
  visitEvent = [];
  visitItem: Visit[];
  token = JSON.parse(localStorage.getItem('socialusers'));

  constructor(
    private activateRoute: ActivatedRoute,
    public visitService: VisitService,
    public eventService: EventService,
    public config: Configuration,
    public toastr: ToastrService
  ) {
    this.subscription = activateRoute.params.subscribe(params => this.id = params['eventId']);
  }

  ngOnInit(): void {
    this.visitService.GetVisitorsList(this.id).subscribe((res: any) => {
      debugger;
      this.visitItem = res;
      console.log(res)
      this.visitorsCounter(res);
      this.visitEvent = Array(this.visitItem.length).fill(0).map((x, i) => ({ data: this.visitItem[i] }));
    });
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }

  editEvent(eventItem: EventItem) {
    this.tableMode = false;
    this.eventView = eventItem;
  }

  visitorsCounter(visitors: Visit[]) {
    if (visitors.length == 0) {
      this.isVisitorsExists = false;
    }
    else
      this.isVisitorsExists = true;
  }

  cancel() {
    this.tableMode = true;
    this.eventService.GetEventById(this.eventView.Id);
  }

  save() {
    if (!this.eventView.Name || !this.eventView.Location || !this.eventView.Description || !this.eventView.Date) {
      this.toastr.error('Fill out all the fields','Error');
    } 
    else {
      this.eventService.EditEvent(this.eventView.Id, this.eventView).subscribe(res => { console.log('success') });
      this.tableMode = true;
    }
  }
}

import { Component, OnInit } from '@angular/core';

import { EventItem } from '../shared/models/event-model';
import { EventService } from '../shared/services/event-service';
import { Configuration } from '../shared/config/configuration';
import { AuthenticateService } from '../shared/services/auth-service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styles: [
  ]
})

export class HomePageComponent implements OnInit {
  eventItems: EventItem[];
  publicEvents = [];
  pageOfItemsEvent: Array<EventItem>;
  //token = JSON.parse(localStorage.getItem('socialusers'));
  //qwe:string;

  constructor(
    public eventService:EventService,
    public config: Configuration,
    public auth: AuthenticateService
  ) { }

  ngOnInit(): void {
    this.eventService.GetPublicEvents().subscribe((res: any) => {
      this.eventItems = res;
      this.publicEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ data: this.eventItems[i] }));
    });
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }
}

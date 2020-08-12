import { Component, OnInit } from '@angular/core';

import { EventItem } from '../shared/models/event-model';
import { EventService } from '../shared/services/event-service';
import { Configuration } from '../shared/config/configuration';
import { GoogleAuthService } from '../shared/services/auth-service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styles: [
  ]
})

export class HomePageComponent implements OnInit {
  eventItem: EventItem[];
  itemsEvent = [];
  pageOfItemsEvent: Array<EventItem>;
  token = JSON.parse(localStorage.getItem('socialusers'));
  qwe:string;

  constructor(
    public eventService:EventService,
    public config: Configuration,
    public auth: GoogleAuthService
  ) { }

  ngOnInit(): void {

    this.auth.AuthCookie().subscribe(response => {
      const token = (<any>response).token;
      localStorage.setItem("jwt", token);
     
    }, err => {
      
    });
    // this.eventService.GetEventList().subscribe((res: any) => {
    //   this.eventItem = res;
    //   this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
    // });
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }
}

import { Component, OnInit } from '@angular/core';
import { EventItem } from '../shared/models/event-model';
import { EventService } from '../shared/services/event-service';
import { ImgUtil } from '../utils/img-util';
import { GoogleAnalytics } from '../shared/services/google-analytics-service';

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

  constructor(
    public eventService:EventService,
    public imgUtil: ImgUtil,
    public ga: GoogleAnalytics
  ) { }

  ngOnInit(): void {
    this.ga.homePage();
    this.ga.homeClick();
    this.eventService.GetPublicEvents().subscribe((res: any) => {
      this.eventItems = res;
      this.publicEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ event: this.eventItems[i] }));
    });
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }
}

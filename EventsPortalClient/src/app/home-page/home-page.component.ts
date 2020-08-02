import { Component, OnInit } from '@angular/core';
import { EventItem } from '../shared/models/event-model';
import { EventService } from '../shared/services/event-service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styles: [
  ]
})
export class HomePageComponent implements OnInit {
  eventItem: EventItem[];
  itemsEvent = [];

  constructor(
    public eventService:EventService
  ) { }

  ngOnInit(): void {
    // this.eventService.GetAllowedEventList(this.token.Message).subscribe((res: any) => {
    //   this.eventItem = res;
    //   console.log(res)
    //   this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
    // });
  }
  
  pageOfItemsEvent: Array<EventItem>;

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }
}
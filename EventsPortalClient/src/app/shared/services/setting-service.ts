import { Injectable } from '@angular/core';
import { EventService } from '../services/event-service';

@Injectable()
export class SettingService {

  public snippet;

  constructor(private config: EventService) { }

  ngOnInit() {
    // this.config.getData()
    //   .subscribe(data => {
    //       debugger;
    //     console.log(data);
    //     this.snippet = data;
    //   });
  }
}

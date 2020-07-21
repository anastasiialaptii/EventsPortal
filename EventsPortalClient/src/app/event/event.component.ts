import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EventService } from 'app/shared/services/event.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styles: []
})
export class EventComponent implements OnInit {

  constructor(private eventService: EventService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    if (this.eventService.formData.Id == 0)
      this.InsertEvent(form);
  }

  InsertEvent(form: NgForm) {
    this.eventService.CreateEvent().subscribe(
      res => { debugger; },
      err => {
        debugger;
        console.log(err);
      }
    )
  }
}

import { Component, OnInit } from '@angular/core';

import { EventService } from '../shared/services/event-service';
import { VisitService } from '../shared/services/visit-service';
import { UserService } from '../shared/services/user-service';
import { Visit } from '../shared/models/visit-model';
import { EventItem } from '../shared/models/event-model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-allowed-event-list',
  templateUrl: './allowed-event-list.component.html',
  styles: [
  ]
})

export class AllowedEventListComponent implements OnInit {
  token = JSON.parse(localStorage.getItem('socialusers'));
  userId: number;
  visit: Visit;
  tableMode: boolean = true;
  itemsEvent = [];
  eventType = [
    { Id: 1, Name: "Private" },
    { Id: 2, Name: "Public" }
  ];
  eventItem: EventItem[];
  pageOfItemsEvent: Array<EventItem>;
  event: EventItem = new EventItem();

  constructor(
    public eventService: EventService,
    public visitService: VisitService,
    public userService: UserService
  ) { }

  ngOnInit(): void {
    this.resetForm();
    this.eventService.GetAllowedEventList().subscribe((res: any) => {
      this.eventItem = res;
      debugger;
      console.log(res)
      this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
    });
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }

  onSubmit(form: NgForm) {
    if (this.eventService.formData.Id == 0) {
      this.createEvent(form);
    }
  }

  cancel() {
    this.event = new EventItem();
    this.tableMode = true;
  }

  add() {
    this.cancel();
    this.tableMode = false;
  }
  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();

    this.userService.GetUserByToken(this.token.Message).subscribe(
      res => {
        this.eventService.formData = {
          Id: 0,
          Name: '',
          Location: '',
          Description: '',
          ImageURI: '',
          EventTypeId: 1,
          OrganizerId: res
        }
      }
    )
  }

  createEvent(form: NgForm) {
    this.eventService.CreateEvent().subscribe(
      res => {
        this.eventService.GetPrivateEventList(this.token.Message);
        this.resetForm();
      },
      err => {
        debugger;
        console.log(err);
      })
  }

  createVisit(id: number) {
    this.userService.GetUserByToken(this.token.Message).subscribe(
      res => {
        this.visit = {
          EventId: id,
          UserId: res
        }
        this.visitService.CreateVisit(this.visit).subscribe(
          res => { console.log("success") },
          err => {
            debugger;
            console.log(err);
          });
      }
    )
  }
}

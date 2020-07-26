import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { EventService } from '../shared/services/event-service';
import { UserService } from '../shared/services/user-service';
import { EventItem } from '../shared/models/event-model';

@Component({
  selector: 'app-private-event-list',
  templateUrl: './private-event-list.component.html',
  styles: [
  ]
})

export class PrivateEventListComponent implements OnInit {
  token = JSON.parse(localStorage.getItem('socialusers'));
  userId: number;
  eventItem: EventItem = new EventItem();
  tableMode: boolean = true;
  constructor(
    public eventService: EventService,
    public userService: UserService
  ) { }

  ngOnInit(): void {
    this.eventService.GetPrivateEventList(this.token.Message);
    this.resetForm();
  }

  onSubmit(form: NgForm) {
    if (this.eventService.formData.Id == 0) {
      this.createEvent(form);
    }
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

  onDelete(id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.eventService.DeleteEvent(id)
        .subscribe(res => {
          this.eventService.GetPrivateEventList(this.token.Message);
        },
          err => {
            debugger;
            console.log(err);
          })
    }
  }

  editProduct(event: EventItem) {
    this.eventItem = event;
  }

  cancel() {
    this.eventItem = new EventItem();
    this.tableMode = true;
  }

  add() {
    this.cancel();
    this.tableMode = false;
  }

  save() {
    this.eventService.EditEvent(this.eventItem.Id, this.eventItem)
      .subscribe(res => {
        this.eventService.GetPrivateEventList(this.token.Message);
      },
        err => {
          debugger;
          console.log(err);
        })
  }
}

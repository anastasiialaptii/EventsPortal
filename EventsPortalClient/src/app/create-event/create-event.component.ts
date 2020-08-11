import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { EventService } from '../shared/services/event-service';
import { UserService } from '../shared/services/user-service';
import { Configuration } from '../shared/config/configuration';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styles: [
  ]
})

export class CreateEventComponent implements OnInit {
  response: { "dbPath": '' };
  token = JSON.parse(localStorage.getItem('socialusers'));

  constructor(
    public eventService: EventService,
    public userService: UserService,
    private router: Router,
    public config: Configuration,
    public toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  onSubmit(form: NgForm) {
    if (this.eventService.FormData.Id == 0) {
      if (!this.eventService.FormData.ImageURI || !this.eventService.FormData.Date)
        this.toastr.error('Something wrong!', 'Error');
      else {
        this.createEvent(form);
        this.toastr.success('Added new event', 'Success');
      }
    }
    else {
      this.toastr.error('Something wrong!', 'Error');
    }
  }

  createEvent(form: NgForm) {
    this.eventService.CreateEvent().subscribe(
      res => {
        debugger;
        this.router.navigate(['/allowed-event-list']);
        this.resetForm();
      },
      err => {
        debugger;
        console.log(err);
      })
  }

  uploadFinished = (event) => {
    this.response = event;
    debugger;
    this.eventService.FormData.ImageURI = this.response.dbPath;
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.eventService.SearchEventFormData = {
      Name: ''
    };
    this.userService.GetUserByToken(this.token.Message).subscribe(
      res => {
        this.eventService.FormData = {
          Id: 0,
          Name: '',
          Location: '',
          Description: '',
          EventTypeId: 1,
          Date: null,
          OrganizerId: res
        }
      }
    )
  }
}

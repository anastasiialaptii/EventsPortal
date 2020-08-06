import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { EventService } from '../shared/services/event-service';
import { UserService } from '../shared/services/user-service';
import { Configuration } from '../shared/config/configuration';

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
    public config: Configuration
    ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  onSubmit(form: NgForm) {
    if (this.eventService.FormData.Id == 0) {
      this.createEvent(form);
    }
  }

  createEvent(form: NgForm) {
    this.eventService.CreateEvent().subscribe(
      res => {
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
          OrganizerId: res
        }
      }
    )
  }
}

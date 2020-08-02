import { Component, OnInit } from '@angular/core';
import { EventService } from '../shared/services/event-service';
import { UserService } from '../shared/services/user-service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styles: [
  ]
})
export class CreateEventComponent implements OnInit {
  eventTypes = [
    { Id: 1, Name: "Private" },
    { Id: 2, Name: "Public" }
  ];
  public response: { "dbPath": '' };
  token = JSON.parse(localStorage.getItem('socialusers'));
  
  constructor(
    public eventService: EventService,
    public userService: UserService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  onSubmit(form: NgForm) {
    if (this.eventService.formData.Id == 0) {
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

  public uploadFinished = (event) => {
    this.response = event;
    debugger;
    this.eventService.formData.ImageURI = this.response.dbPath;
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.eventService.searchEventFormData = {
      Name: ''
    };
    this.userService.GetUserByToken(this.token.Message).subscribe(
      res => {
        this.eventService.formData = {
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

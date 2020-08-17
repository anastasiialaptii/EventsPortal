import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { EventService } from '../shared/services/event-service';
import { UserService } from '../shared/services/user-service';
import { Configuration } from '../shared/config/configuration';

import { ToastrService } from 'ngx-toastr';
import { HttpEventType } from '@angular/common/http';
import { UploadService } from '../shared/services/upload-service';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styles: [
  ]
})

export class CreateEventComponent implements OnInit {
  response;
  public progress: number;
  public message: string;

  constructor(
    public uploadService: UploadService,
    public eventService: EventService,
    public userService: UserService,
    private router: Router,
    public config: Configuration,
    public toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  onSubmit(form: NgForm, files) {
    if (files.length === 0) {
      this.toastr.error('Something wrong!', 'Error');
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.uploadService.UploadImage(formData)
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) { 
          debugger;
          this.progress = Math.round(100 * event.loaded / event.total); 
          debugger;    
        }
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.response = event.body;
          this.eventService.FormData.ImageURI = this.response.dbPath;
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
      });
  }

  createEvent(form: NgForm) {
    this.eventService.CreateEvent().subscribe(
      res => {
        this.router.navigate(['/allowed-event-list']);
        this.resetForm();
      },
      err => {
      })
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();

    this.eventService.FormData = {
      Id: 0,
      Name: '',
      Location: '',
      Description: '',
      EventTypeId: 1,
      Date: null,
      OrganizerId: 0
    }
  }
}

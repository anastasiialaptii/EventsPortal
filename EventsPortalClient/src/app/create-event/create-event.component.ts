import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EventService } from '../shared/services/event-service';
import { UserService } from '../shared/services/user-service';
import { Configuration } from '../shared/config/configuration';
import { ToastrService } from 'ngx-toastr';
import { UploadService } from '../shared/services/upload-service';
import { ImgUtil } from '../utils/img-util';
import { EventValidator } from '../utils/event-validator';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styles: [
  ]
})

export class CreateEventComponent implements OnInit {

  constructor(
    public uploadService: UploadService,
    public eventService: EventService,
    public userService: UserService,
    private router: Router,
    public config: Configuration,
    public toastr: ToastrService,
    public imgUtil: ImgUtil,
    public eventValidator: EventValidator
  ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  onSubmit( files) {
    this.uploadService.UploadImage(this.imgUtil.downloadImg(files))
      .subscribe(event => {
        if(this.eventValidator.isEventValid(event))
        {
          this.eventService.CreateEvent().subscribe(
            res => {
              this.router.navigate(['/event-list']);
              this.resetForm();
            },
            err => {
            })
        }
  });
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

import { Component, OnInit } from '@angular/core';
import { UploadService } from '../shared/services/upload-service';
import { ImgUtil } from '../utils/img-util';
import { EventValidator } from '../utils/event-validator';
import { EventService } from '../shared/services/event-service';
import { Router } from '@angular/router';
import { EventHelper } from '../utils/event-helper';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styles: [
  ]
})

export class CreateEventComponent implements OnInit {

  constructor(
    public uploadService: UploadService,
    public imgUtil: ImgUtil,
    public eventValidator: EventValidator,
    public eventService: EventService,
    private router: Router,
    public eventHelper: EventHelper,
    public toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  onSubmit(files) {
    this.uploadService.UploadImage(this.imgUtil.downloadImg(files))
      .subscribe(event => {
        if (this.imgUtil.createImgPath(event)) {
          if (this.eventValidator.isEventValid(this.eventService.FormData)) {
            this.toastr.success('Event added', 'Success');
            this.eventService.CreateEvent().subscribe(
              res => {
                this.router.navigate(['/event-list']);
                this.resetForm();
              },
              err => {
                err
              })
          }
        }
      });
  }

  resetForm(form?: NgForm) {
    this.eventHelper.resetForm(form);

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

import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Configuration } from '../shared/config/configuration'
import { VisitService } from '../shared/services/visit-service';
import { EventService } from '../shared/services/event-service'; 0
import { EventItem } from '../shared/models/event-model';
import { Visit } from '../shared/models/visit-model';
import { ToastrService } from 'ngx-toastr';
import { UploadService } from '../shared/services/upload-service';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-visitors-list',
  templateUrl: './visitors-list.component.html',
  styles: [
  ]
})

export class VisitorsListComponent implements OnInit {
  private subscription: Subscription;
  id: number;
  eventEdit: EventItem;
  eventView: EventItem = new EventItem();
  isVisitorsExists: boolean = false;
  pageOfItemsEvent: Array<Visit>;
  visitorsPerEventList = [];
  visitor: Visit[];
  token = JSON.parse(localStorage.getItem('token'));
  tableMode: boolean = true;
  response;

  constructor(
    private activateRoute: ActivatedRoute,
    public visitService: VisitService,
    public eventService: EventService,
    public config: Configuration,
    public toastr: ToastrService,
    public uploadService: UploadService
  ) {
    this.subscription = activateRoute.params.subscribe(params => this.id = params['eventId']);
  }

  ngOnInit(): void {
    this.eventService.GetEvent(this.id).subscribe(res => { this.eventEdit = res });
    this.visitService.GetVisitorsPerEvent(this.id).subscribe((res: any) => {
      this.visitor = res;
      this.visitorsCounter(res);
      this.visitorsPerEventList = Array(this.visitor.length).fill(0).map((x, i) => ({ data: this.visitor[i] }));
    });
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }

  visitorsCounter(visitors: Visit[]) {
    if (visitors.length == 0) {
      this.isVisitorsExists = false;
    }
    else
      this.isVisitorsExists = true;
  }

  editEvent(eventItem: EventItem) {
    this.tableMode = false;
    this.eventView = eventItem;
  }

  save(files) {
    if (!this.eventView.Name || !this.eventView.Location || !this.eventView.Description || !this.eventView.Date || !this.eventView.ImageURI || this.eventView.Name.length > 20) {
      this.toastr.error('Fill out all the fields', 'Error');
    }
    else {
      if (files.length === 0) {
        this.eventService.EditEvent(this.eventView.Id, this.eventView).subscribe(res => { res });
              this.tableMode = true;
              this.toastr.success('Event has been updated', 'Success');
      }
      else {
        let fileToUpload = <File>files[0];
        const formData = new FormData();
        formData.append('file', fileToUpload, fileToUpload.name);
        this.uploadService.UploadImage(formData)
          .subscribe(event => {
            if (event.type === HttpEventType.Response) {
              this.response = event.body;
              this.eventView.ImageURI = this.response.dbPath;
              this.eventService.EditEvent(this.eventView.Id, this.eventView).subscribe(res => { res });
              this.tableMode = true;
              this.toastr.success('Event has been updated', 'Success');
            }
          });
      }
    }
  }

    cancel() {
      this.tableMode = true;
      this.eventService.GetEvent(this.id).subscribe(res => { this.eventEdit = res });
    }
  }

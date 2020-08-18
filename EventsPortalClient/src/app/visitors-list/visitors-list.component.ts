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
import { ImgUtil } from '../utils/img-util';
import { EventValidator } from '../utils/event-validator';

@Component({
  selector: 'app-visitors-list',
  templateUrl: './visitors-list.component.html',
  styles: [
  ]
})

export class VisitorsListComponent implements OnInit {
  private subscription: Subscription;
  id: number;
 // eventEdit: EventItem;
  eventView: EventItem = new EventItem();
  isVisitorsExists: boolean = false;
  pageOfItemsEvent: Array<Visit>;
  visitorsPerEventList = [];
  visitor: Visit[];
  token = JSON.parse(localStorage.getItem('token'));
  tableMode: boolean = true;

  constructor(
    private activateRoute: ActivatedRoute,
    public visitService: VisitService,
    public eventService: EventService,
    public imgUtil: ImgUtil,
    public toastr: ToastrService,
    public uploadService: UploadService,
    public eventValidator: EventValidator,
    public config: Configuration
  ) {
    this.subscription = activateRoute.params.subscribe(params => this.id = params['eventId']);
  }

  ngOnInit(): void {
    this.eventService.GetEvent(this.id).subscribe(res => { this.eventService.FormData = res });
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
    this.eventView = this.eventService.FormData;
  }

  save(files) {
      if (files.length === 0) {
        this.eventService.EditEvent(this.eventService.FormData.Id, this.eventService.FormData).subscribe(res => { res });
        this.tableMode = true;
        this.toastr.success('Event has been updated', 'Success');
      }
      else {     
        this.uploadService.UploadImage(this.imgUtil.downloadImg(files))
          .subscribe(event => {
            if (this.eventValidator.isEventValid(event)) {
              this.eventService.EditEvent(this.eventService.FormData.Id, this.eventService.FormData).subscribe(res => { res });
              this.tableMode = true;
              this.toastr.success('Event has been updated', 'Success');
            }
          });
      }
    }

  cancel() {
    this.tableMode = true;
    this.eventService.GetEvent(this.id).subscribe(res => { this.eventService.FormData = res });
  }
}

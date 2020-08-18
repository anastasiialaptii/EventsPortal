import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { EventService } from '../shared/services/event-service';
import { VisitService } from '../shared/services/visit-service';
import { UserService } from '../shared/services/user-service';
import { Visit } from '../shared/models/visit-model';
import { EventItem } from '../shared/models/event-model';
import { ImgUtil } from '../utils/img-util';
import { Router } from '@angular/router';
import { ConfirmationDialogService } from '../confirmation-dialog/confirmation-dialog.service';
import { AuthenticateService } from '../shared/services/auth-service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styles: [
  ]
})

export class EventListComponent implements OnInit {
  visit: Visit;
  token = JSON.parse(localStorage.getItem('token'));
  publicOwnEvents = [];
  eventItems: EventItem[];
  pageOfItemsEvent: Array<EventItem>;
  event: EventItem = new EventItem();
  GetEnrollEventList: Visit[];
  GetConfirmedVisitList: number[];

  constructor(
    public confirmationDialogService: ConfirmationDialogService,
    public eventService: EventService,
    public visitService: VisitService,
    public userService: UserService,
    public imgUtil: ImgUtil,
    public router: Router,
    public toastr: ToastrService,
    public authService: AuthenticateService
  ) { }

  ngOnInit(): void {
    this.resetForm();
    this.visitService.GetConfirmedVisits().subscribe(res => { this.GetConfirmedVisitList = res as number[] });
    this.eventService.GetPublicOwnEvents().subscribe((res: any) => {
      this.eventItems = res;
      this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ event: this.eventItems[i] }));
    });
  }

  onSearchEvent(eventName: string) {
    if (eventName.length > 1) {
      this.eventService.SearchEvents(eventName).subscribe((res: any) => {
        this.eventItems = res;
        this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ event: this.eventItems[i] }));
      });
    }
    else {
      this.eventService.GetPublicOwnEvents().subscribe((res: any) => {
        this.eventItems = res;
        this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ event: this.eventItems[i] }));
      });
    }
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }

  onEventDetails(idEvent: number) {
    this.eventService.GetEvent(idEvent);
    this.router.navigate(["/visitors-list/" + idEvent]);
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();

    this.eventService.SearchEventFormData = {
      Name: ''
    };
  }

  createVisit(idEvent: number) {
    this.visit = {
      EventId: idEvent,
      UserId: 0
    }
    this.visitService.CreateVisit(this.visit).subscribe(
      res => {
        res;
        this.toastr.success('Participation confirmed', 'Success');
        this.visitService.GetConfirmedVisits().subscribe(res => { this.GetConfirmedVisitList = res as number[] });
        this.visitService.GetEnrollEvents().subscribe(res => { this.GetEnrollEventList = res as Visit[] });
        this.eventService.GetPublicOwnEvents().subscribe((res: any) => {
          this.eventItems = res;
          this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ data: this.eventItems[i] }));
        });
      },
      err => {
        this.toastr.warning('Participation already confirmed', 'Warning');
      });
  }

  onDelete(idEvent: number, idUser: string) {
    this.confirmationDialogService.confirm()
      .then((confirmed) =>
        this.eventService.DeleteEvent(idEvent, idUser)
          .subscribe(res => {
            this.eventService.GetPublicOwnEvents().subscribe((res: any) => {
              this.eventItems = res;
              this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ event: this.eventItems[i] }));
              this.toastr.info('Event successfully deleted', 'Info');
            })
          }),
        err => {
          err
        })
      .catch(() => console.log('User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'));
  }

  isUserCanJoin(eventId: number) {
    if(this.GetConfirmedVisitList.some(x=>x===eventId))
    return true;
  }
}

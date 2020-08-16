import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { EventService } from '../shared/services/event-service';
import { VisitService } from '../shared/services/visit-service';
import { UserService } from '../shared/services/user-service';
import { Visit } from '../shared/models/visit-model';
import { EventItem } from '../shared/models/event-model';
import { Configuration } from '../shared/config/configuration';
import { Router } from '@angular/router';
import { ConfirmationDialogService } from '../confirmation-dialog/confirmation-dialog.service';
import { AuthenticateService } from '../shared/services/auth-service';

@Component({
  selector: 'app-allowed-event-list',
  templateUrl: './allowed-event-list.component.html',
  styles: [
  ]
})

export class AllowedEventListComponent implements OnInit {
  userId: number;
  visit: Visit;
  token = JSON.parse(localStorage.getItem('token'));
  publicOwnEvents = [];
  eventItems: EventItem[];
  pageOfItemsEvent: Array<EventItem>;
  event: EventItem = new EventItem();
  GetEnrollEventsList: Visit[];

  constructor(
    public confirmationDialogService: ConfirmationDialogService,
    public eventService: EventService,
    public visitService: VisitService,
    public userService: UserService,
    public config: Configuration,
    public router: Router,
    public toastr: ToastrService,
    public authService: AuthenticateService
  ) { }

  ngOnInit(): void {
    this.resetForm();
    this.visitService.GetEnrollEvents().subscribe(res => { this.GetEnrollEventsList = res as Visit[] });
    this.eventService.GetPublicOwnEvents().subscribe((res: any) => {
      this.eventItems = res;
      this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ data: this.eventItems[i] }));
    });
  }

  onSearchEvent(name: string) {
    if (name.length > 1) {
      this.eventService.SearchEvents(name).subscribe((res: any) => {
        this.eventItems = res;
        console.log(res)
        this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ data: this.eventItems[i] }));
      });
    }
    else {
      this.eventService.GetPublicOwnEvents().subscribe((res: any) => {
        this.eventItems = res;
        this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ data: this.eventItems[i] }));
      });
    }
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }

  onEventDetails(eventId: number) {
    this.eventService.GetEvent(eventId);
    this.router.navigate(["/visitors-list/" + eventId]);
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();

    this.eventService.SearchEventFormData = {
      Name: ''
    };
  }

  createVisit(id: number) {
    this.visit = {
      EventId: id,
      UserId: 0
    }
    this.visitService.CreateVisit(this.visit).subscribe(
      res => {
        res;
        this.toastr.success('Participation confirmed', 'Success');
        this.visitService.GetEnrollEvents().subscribe(res => { this.GetEnrollEventsList = res as Visit[] });
        this.eventService.GetPublicOwnEvents().subscribe((res: any) => {
          this.eventItems = res;
          this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ data: this.eventItems[i] }));
        });
      },
      err => {
        this.toastr.warning('Participation already confirmed', 'Warning');
      });
  }

  onDelete(id: number, idUser: string) {
    this.confirmationDialogService.confirm()
      .then((confirmed) =>
        this.eventService.DeleteEvent(id, idUser)
          .subscribe(res => {
            this.eventService.GetPublicOwnEvents().subscribe((res: any) => {
              this.eventItems = res;
              this.publicOwnEvents = Array(this.eventItems.length).fill(0).map((x, i) => ({ data: this.eventItems[i] }));
              this.toastr.info('Event successfully deleted', 'Info');
            })
          }),
        err => {
          err
        })
      .catch(() => console.log('User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'));
  }
}

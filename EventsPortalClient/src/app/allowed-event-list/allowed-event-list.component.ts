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
import { AuthComponent } from '../auth/auth.component';
import { GoogleAuthService } from '../shared/services/auth-service';
import { AuthService } from 'angular-6-social-login';

@Component({
  selector: 'app-allowed-event-list',
  templateUrl: './allowed-event-list.component.html',
  styles: [
  ]
})

export class AllowedEventListComponent implements OnInit {
  token = JSON.parse(localStorage.getItem('socialusers'));
  userId: number;
  visit: Visit;
  itemsEvent = [];
  eventItem: EventItem[];
  pageOfItemsEvent: Array<EventItem>;
  event: EventItem = new EventItem();

  constructor(
    public confirmationDialogService: ConfirmationDialogService,
    public eventService: EventService,
    public visitService: VisitService,
    public userService: UserService,
    public config: Configuration,
    public router: Router,
    public toastr: ToastrService,
    public authService: GoogleAuthService
  ) { }

  ngOnInit(): void {
    this.authService.AuthCookie().subscribe(res => { console.log('success') }, err => { console.log('------') });

    this.resetForm();
    this.eventService.GetAllowedToVisitEvent(this.token.Message);
    this.eventService.GetAllowedEventList(this.token.Message).subscribe((res: any) => {
      this.eventItem = res;
      console.log(res)
      this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
    });
  }

  onSearchEvent(name: string) {
    if (name.length > 1) {
      this.eventService.GetAllowedEventList(this.token.Message, name).subscribe((res: any) => {
        this.eventItem = res;
        console.log(res)
        this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
      });
    }
    else {
      this.eventService.GetAllowedEventList(this.token.Message).subscribe((res: any) => {
        this.eventItem = res;
        console.log(res)
        this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
      });
    }
  }



  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }

  isUserLogged(idEventUser: string) {
    if (this.token.Message == idEventUser)
      return true;
  }

  onEventDetails(eventId: number) {
    this.eventService.GetEventById(eventId);
    this.router.navigate(["/visitors-list/" + eventId]);
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

  createVisit(id: number) {
    this.userService.GetUserByToken(this.token.Message).subscribe(
      res => {
        this.visit = {
          EventId: id,
          UserId: res
        }
        this.visitService.CreateVisit(this.visit).subscribe(
          res => {
            console.log("success");
            this.toastr.success('Participation confirmed', 'Success');
            this.eventService.GetAllowedEventList(this.token.Message).subscribe((res: any) => {
              this.eventItem = res;
              console.log(res)
              this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
              this.eventService.GetAllowedToVisitEvent(this.token.Message);
            });
          },
          err => {
            debugger;
            console.log(err);
            console.log("success");
            this.toastr.warning('Participation already confirmed', 'Warning');
          });
      }
    )
  }

  onDelete(id) {
    this.confirmationDialogService.confirm()
      .then((confirmed) =>
        this.eventService.DeleteEvent(id)
          .subscribe(res => {
            this.eventService.GetAllowedEventList(this.token.Message, this.eventService.SearchEventFormData.Name).subscribe((res: any) => {
              this.eventItem = res;
              debugger;
              console.log(res)
              this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
              this.toastr.info('Event successfully deleted', 'Info');
            })
          }),
        err => {
          debugger;
          console.log(err);
        })
      .catch(() => console.log('User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'));
  }
}

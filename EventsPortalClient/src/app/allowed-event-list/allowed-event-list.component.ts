import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { EventService } from '../shared/services/event-service';
import { VisitService } from '../shared/services/visit-service';
import { SettingService } from '../shared/services/setting-service';

import { UserService } from '../shared/services/user-service';
import { Visit } from '../shared/models/visit-model';
import { EventItem } from '../shared/models/event-model';
import { DomSanitizer } from '@angular/platform-browser';


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
  tableMode: boolean = true;
  itemsEvent = [];
  eventTypes = [
    { Id: 1, Name: "Private" },
    { Id: 2, Name: "Public" }
  ];
  eventItem: EventItem[];
  pageOfItemsEvent: Array<EventItem>;
  event: EventItem = new EventItem();
  thumbnail: any;

  public snippet;
  constructor(
    public eventService: EventService,
    public visitService: VisitService,
    public userService: UserService,
    public setting: SettingService,
    private sanitizer: DomSanitizer

  ) { }

  ngOnInit(): void {

    this.eventService.getData()
      .subscribe((baseImage: any) => {
        let objectURL = 'data:image/jpeg;base64,' + baseImage.image;
        this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
      });
    this.resetForm();
    this.eventService.GetSearchedEventList();
    this.eventService.GetAllowedEventList(this.token.Message).subscribe((res: any) => {
      this.eventItem = res;
      console.log(res)
      this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
    });
  }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }

  onSubmit(form: NgForm) {
    if (this.eventService.formData.Id == 0) {
      this.createEvent(form);
      this.tableMode = true;
    }
  }

  onSearchEvent() {
    if (this.eventService.searchEventFormData.Name != null) {
      this.eventService.GetSearchedEventList();
    }
  }

  onEventDetails(eventId: number) {
    this.visitService.GetVisitorsList(eventId);
  }

  cancel() {
    this.event = new EventItem();
    this.tableMode = true;
  }

  add() {
    this.cancel();
    this.tableMode = false;
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
          ImageURI: '',
          EventTypeId: 1,
          OrganizerId: res
        }
      }
    )
  }

  createEvent(form: NgForm) {
    this.eventService.CreateEvent().subscribe(
      res => {
        this.eventService.GetPrivateEventList(this.token.Message);
        this.resetForm();
      },
      err => {
        debugger;
        console.log(err);
      })
  }

  createVisit(id: number) {
    this.userService.GetUserByToken(this.token.Message).subscribe(
      res => {
        this.visit = {
          EventId: id,
          UserId: res
        }
        this.visitService.CreateVisit(this.visit).subscribe(
          res => { console.log("success") },
          err => {
            debugger;
            console.log(err);
          });
      }
    )
  }
}

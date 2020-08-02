import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { EventService } from '../shared/services/event-service';
import { VisitService } from '../shared/services/visit-service';
import { SettingService } from '../shared/services/setting-service';

import { UserService } from '../shared/services/user-service';
import { Visit } from '../shared/models/visit-model';
import { EventItem } from '../shared/models/event-model';
import { DomSanitizer } from '@angular/platform-browser';
// import { HttpEventType } from '@angular/common/http';

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
  response: { "dbPath": '' };
  // thumbnail: any; //download img
  // public snippet; //download img

  constructor(
    public eventService: EventService,
    public visitService: VisitService,
    public userService: UserService,
    public setting: SettingService,
    private sanitizer: DomSanitizer

  ) { }

  ngOnInit(): void {
    this.resetForm();
    // getting image
    // this.eventService.getData()
    //   .subscribe((baseImage: any) => {
    //     let objectURL = 'data:image/jpeg;base64,' + baseImage.image;
    //     this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
    //   });
    this.eventService.GetAllowedEventList(this.token.Message).subscribe((res: any) => {
      this.eventItem = res;
      console.log(res)
      this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
    });
  }

  onSearchEvent() {
    if (this.eventService.searchEventFormData.Name != null) {
      this.eventService.GetAllowedEventList(this.token.Message, this.eventService.searchEventFormData.Name).subscribe((res: any) => {
        this.eventItem = res;
        debugger;
        console.log(res)
        this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
      });
    }
  }

  public createImgPath = (serverPath: string) => {
    return `http://localhost:50618/${serverPath}`;
  }

  // public uploadFinished = (event) => {
  //   this.response = event;
  //   debugger;
  //   this.eventService.formData.ImageURI = this.response.dbPath;
  // }

  onChangePage(pageOfItemsEvent: Array<any>) {
    this.pageOfItemsEvent = pageOfItemsEvent;
  }

  // onSubmit(form: NgForm) {
  //   if (this.eventService.formData.Id == 0) {
  //     this.createEvent(form);
  //     this.tableMode = true;
  //   }
  // }

  // createEvent(form: NgForm) {
  //   this.eventService.CreateEvent().subscribe(
  //     res => {
  //       //this.eventService.GetPrivateEventList(this.token.Message);
  //       this.resetForm();
  //     },
  //     err => {
  //       debugger;
  //       console.log(err);
  //     })
  // }

  isUserLogged(idEventUser:string){
    if(this.token.Message==idEventUser)
    return true;
  }

  onEventDetails(eventId: number) {
    this.visitService.GetVisitorsList(eventId);
  }

  cancel() {
    this.event = new EventItem();
    this.tableMode = true;
  }

  // add() {
  //   this.cancel();
  //   this.tableMode = false;
  // }

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
          //ImageURI: '',
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
          res => { console.log("success") },
          err => {
            debugger;
            console.log(err);
          });
      }
    )
  }

  onDelete(id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.eventService.DeleteEvent(id)
        .subscribe(res => {
          this.eventService.GetAllowedEventList(this.token.Message, this.eventService.searchEventFormData.Name).subscribe((res: any) => {
            this.eventItem = res;
            debugger;
            console.log(res)
            this.itemsEvent = Array(this.eventItem.length).fill(0).map((x, i) => ({ data: this.eventItem[i] }));
          });
        },
          err => {
            debugger;
            console.log(err);
          })
    }
  }
}

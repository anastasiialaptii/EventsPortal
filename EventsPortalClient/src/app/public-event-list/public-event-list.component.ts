import { Component, OnInit } from '@angular/core';

import { EventService } from '../shared/services/event-service';
import { VisitService } from '../shared/services/visit-service';
import { UserService } from '../shared/services/user-service';
import { Visit } from '../shared/models/visit-model';

@Component({
  selector: 'app-public-event-list',
  templateUrl: './public-event-list.component.html',
  styles: [
  ]
})

export class PublicEventListComponent implements OnInit {
  token = JSON.parse(localStorage.getItem('socialusers'));
  visit: Visit;
  constructor(
    public eventService: EventService,
    public visitService: VisitService,
    public userService: UserService) { }

  ngOnInit(): void {
    this.eventService.GetPublicEventList();  
  }

  createVisit(id:number) {
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

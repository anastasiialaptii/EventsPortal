import { Component, OnInit } from '@angular/core';

import { EventService } from '../shared/services/event-service';
import { User } from '../shared/models/user-model';

@Component({
  selector: 'app-private-event-list',
  templateUrl: './private-event-list.component.html',
  styles: [
  ]
})
export class PrivateEventListComponent implements OnInit {

users:User;
  constructor(public eventService: EventService) { 
   
    //this.eventService.userToken ='ya29.a0AfH6SMD4s6slsKfUQAwbpSjbiCubZDUkrFhaMva4dVrYF7gDLOA_zrGtnsD3px-Nn6aWbY-uPO6sfnaP0SWY8FSRmcjdBD0dRFjS2xp-QemdwIFDJK8yhVWODeHe44FyMKRP6MFJIEfP2_sOuxo8OrOiIxdlmOz6QSBz';
   
  // this.eventService.userToken = x.Message;
  }

  ngOnInit(): void {
    let x = JSON.parse(localStorage.getItem('socialusers'));
    alert(x.Message);
    this.eventService.GetPrivateEventList(x.Message);
  }

}

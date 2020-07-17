import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styles: [
  ]
})
export class UserListComponent implements OnInit {

  constructor(public service:UserService) { }

  ngOnInit(): void {
    this.service.GetUserList();
  }

}

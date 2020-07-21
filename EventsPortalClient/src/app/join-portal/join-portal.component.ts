import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'app/shared/services/user.service';

@Component({
  selector: 'app-join-portal',
  templateUrl: './join-portal.component.html'
})
export class JoinPortalComponent implements OnInit {

  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.userService.formData = {
      Id: 0,
      FirstName: '',
      LastName: '',
      Login:'',
      Password:'',
      UserRoleId: 1,
      AvatarImageURI:'avatarName',
      UserRole:null
    }
  }
  onSubmit(form: NgForm) {
    if (this.userService.formData.Id == 0)
      this.InsertUser(form);     
  }

  InsertUser(form: NgForm) {
    this.userService.CreateUser().subscribe(
      res=>{debugger;},
      err => {
        debugger;
        console.log(err);
      }
    )
  }
}

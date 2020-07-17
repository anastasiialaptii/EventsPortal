import { Component, OnInit } from '@angular/core';
import {UserService} from 'src/app/shared/user.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private router: Router) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      Id: 0,
      FirstName: '',
      LastName: '',
      AvatarImageURI: null,
      UserRoleId:1
    }
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.Id == 0)
      {
        this.InsertBicycle(form);
        
         }
  }

  InsertBicycle(form: NgForm) {
    this.service.CreateUser().subscribe(
      res => {
       this.resetForm();
       this.router.navigate(['/user/user-list']);  
      },
      err => {
        debugger;
        console.log(err);
      }
    )
  }
}
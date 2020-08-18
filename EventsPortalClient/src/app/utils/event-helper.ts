import { NgForm } from '@angular/forms';

export class EventHelper{
    eventTypes = [
        { Id: 1, Name: "Private" },
        { Id: 2, Name: "Public" }
      ];

    minDate = new Date(Date.now());

    resetForm(form?: NgForm){
      if (form != null)
      form.form.reset();
    }
}
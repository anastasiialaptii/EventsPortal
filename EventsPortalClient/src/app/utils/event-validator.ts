import { ToastrService } from 'ngx-toastr';
import { HttpEventType } from '@angular/common/http';
import { EventService } from '../shared/services/event-service';

export class EventValidator {
    response;

    constructor(
        public toastr: ToastrService,
        public eventService: EventService
    ) { }

    isEventValid(event) {
        if (event.type === HttpEventType.Response) {
            this.response = event.body;
            this.eventService.FormData.ImageURI = this.response.dbPath;
            if (this.eventService.FormData.Id == 0) {
                if (!this.eventService.FormData.ImageURI || !this.eventService.FormData.Date)
                    this.toastr.error('Something wrong!', 'Error');
                else {
                    return true;
                }
            }
            else {
                return false;
            }
        }
    }
}
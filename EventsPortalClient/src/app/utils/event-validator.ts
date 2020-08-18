import { ToastrService } from 'ngx-toastr';
import { HttpEventType } from '@angular/common/http';
import { EventService } from '../shared/services/event-service';
import { EventItem } from '../shared/models/event-model';

export class EventValidator {
    response;

    constructor(
        public toastr: ToastrService,
        public eventService: EventService
    ) { }

    isEventValid(eventItem: EventItem) {
        if (!eventItem.Name ||
            !eventItem.Description ||
            !eventItem.Location ||
            !eventItem.Date
            )
         {
            this.toastr.error('Fields cannot be empty', 'Error');
            return false;
        }
        else if(!eventItem.ImageURI)
        {
            this.toastr.error('Upload photo', 'Error');
            return false;
        }
        return true;
    }    
}

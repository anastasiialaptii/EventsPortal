import { ToastrService } from 'ngx-toastr';
import { EventItem } from '../shared/models/event-model';

export class EventValidator {
    constructor(
        public toastr: ToastrService
    ) { }

    isEventValid(eventItem: EventItem) {
        if (!eventItem.Name ||
            !eventItem.Description ||
            !eventItem.Location ||
            !eventItem.Date
        ) {
            this.toastr.error('Fields cannot be empty', 'Error');
            return false;
        }
        else if (!eventItem.ImageURI) {
            this.toastr.error('Upload photo', 'Error');
            return false;
        }
        else if (eventItem.Name.length > 22) {
            this.toastr.error('Event name should be shorter', 'Error');
        }
        return true;
    }
}

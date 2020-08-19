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
            !eventItem.Date ||
            !eventItem.ImageURI
        ) {
            this.toastr.error('Fields cannot be empty', 'Error');
            return false;
        }
        return true;
    }
}

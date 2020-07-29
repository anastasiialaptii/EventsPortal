import { User } from '../models/user-model';
import { EventItem } from '../models/event-model';

export class Visit {
    public EventId: number;
    public UserId: number;
    public User?: User;
    public EventItem?: EventItem;
}

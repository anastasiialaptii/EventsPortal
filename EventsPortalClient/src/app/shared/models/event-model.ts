import { User } from './user-model';
import { EventType } from './event-type';

export class EventItem {
    public Id: number;
    public Name: string;
    public Location: string;
    public Description: string;
    public ImageURI: string;
    public EventTypeId: number;
    public OrganizerId: number;
    public Organizer?: User;
    public TypeEvent?: EventType;
}
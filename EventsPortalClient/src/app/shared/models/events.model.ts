import { User } from "./user.model"
import { EventType } from './eventType.model';

export class Events {
    public Id: number;
    public Name: number;
    public Location: string;
    public Description: string;
    public ImageURI: string;
    public EventTypeId: number;
    public OrganizerId: number;
    public User: User;
    public EventType: EventType;
}

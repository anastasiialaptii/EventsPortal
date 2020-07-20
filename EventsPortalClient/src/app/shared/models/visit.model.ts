import { User } from './user.model';

export class Visit{
    public UserId: number;
    public EventId: number;
    public Event: Event;
    public User: User;
}
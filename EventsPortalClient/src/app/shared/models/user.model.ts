import { UserRole } from './userRole';

export class User{
    public Id: number;
    public FirstName: string;
    public LastName: string;
    public Login: string;
    public Password: string;
    public AvatarImageURI: string;
    public UserRoleId: number;
    public UserRole: UserRole;
}

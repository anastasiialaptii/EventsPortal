using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string AvatarImageURI { get; set; }

        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

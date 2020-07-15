using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] AvatarImage { get; set; }

        public UserRole UserRole { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}

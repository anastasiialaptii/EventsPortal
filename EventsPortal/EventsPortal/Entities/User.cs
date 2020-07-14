using System.Collections.Generic;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] AvatarImage { get; set; }

        public Role Role { get; set; }

        public ICollection<EventUser> EventUser { get; set; }
    }
}

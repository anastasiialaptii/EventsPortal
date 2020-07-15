using System.Collections.Generic;

namespace Core.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

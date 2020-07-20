using System.Collections.Generic;

namespace Service.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string AvatarImageURI { get; set; }

        public int UserRoleId { get; set; }

        public IEnumerable<EventDTO> EventsDTO { get; set; }
    }
}

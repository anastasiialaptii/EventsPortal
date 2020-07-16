using System.Collections.Generic;

namespace Service.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarImageURI { get; set; }

        public int UserRoleId { get; set; }

        public virtual UserRoleDTO UserRoleDTO { get; set; }

        public virtual ICollection<VisitDTO> VisitsDTO { get; set; }

        public virtual ICollection<EventDTO> EventsDTO { get; set; }
    }
}

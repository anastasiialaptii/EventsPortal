using System.Collections.Generic;

namespace Service.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] AvatarImage { get; set; }

        public UserRoleDTO UserRoleDTO { get; set; }

        public ICollection<VisitDTO> VisitsDTO { get; set; }
    }
}

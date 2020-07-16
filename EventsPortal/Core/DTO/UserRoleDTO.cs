using System.Collections.Generic;

namespace Service.DTO
{
    public class UserRoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserDTO> UsersDTO { get; set; }
    }
}

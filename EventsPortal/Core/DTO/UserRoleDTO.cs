using System.Collections.Generic;

namespace Service.DTO
{
    public class UserRoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserDTO> UsersDTO { get; set; }
    }
}

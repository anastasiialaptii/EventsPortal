using Core.DTO;
using System.Collections.Generic;

namespace Service.DTO
{
    public class UserRoleDTO : BaseEntityDTO
    {
        public string Name { get; set; }

        public IEnumerable<UserDTO> UsersDTO { get; set; }
    }
}

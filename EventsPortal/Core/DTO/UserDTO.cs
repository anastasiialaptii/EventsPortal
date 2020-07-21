using Core.DTO;

namespace Service.DTO
{
    public class UserDTO : BaseEntityDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string AvatarImageURI { get; set; }

        public int UserRoleId { get; set; }

        public UserRoleDTO UserRole { get; set; }
    }
}

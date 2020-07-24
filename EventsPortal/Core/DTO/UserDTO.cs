using Core.DTO;

namespace Service.DTO
{
    public class UserDTO : BaseEntityDTO
    {
        public string GoogleId { get; set; }

        public string Email { get; set; }

        public string IdToken { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string Provider { get; set; }

        public string Token { get; set; }
    }
}

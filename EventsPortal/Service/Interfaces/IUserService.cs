using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();

        UserDTO GetUser(int? id);

        Task DeleteUser(int? id);

        Task EditUser(UserDTO userDTO);

        Task AddUser(UserDTO userDTO);

        UserDTO FindUserByEmail(string email);
    }
}

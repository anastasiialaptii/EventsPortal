using Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers();

        Task<UserDTO> GetUserById(int? id);

        Task DeleteUser(int? id);

        Task EditUser(UserDTO userDTO);

        Task AddUser(UserDTO userDTO);

        Task<int> GetUserByToken(string token);
    }
}

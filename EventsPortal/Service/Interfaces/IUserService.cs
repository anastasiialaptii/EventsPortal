using Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers();

        Task<UserDTO> GetUserById(int? id);

        Task DeleteUser(int? id);

        Task EditUser(UserDTO UserDTO);

        Task AddUser(UserDTO UserDTO);
    }
}

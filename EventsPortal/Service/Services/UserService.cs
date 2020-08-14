using AutoMapper;
using Core.Entities;
using Data.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;

        public UserService(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public async Task AddUser(UserDTO UserDTO)
        {
            if (UserDTO != null)
            {
                _dbOperation.Users.Create(
                    _mapper.Map<User>(UserDTO));
                await _dbOperation.SaveAsync();
            }
        }

        public async Task DeleteUser(int? id)
        {
            if (id != null)
            {
                var searchItem = _dbOperation.Users.GetItem(id);

                if (searchItem != null)
                {
                    _dbOperation.Users.Delete(searchItem);
                    await _dbOperation.SaveAsync();
                }
            }
        }

        public async Task EditUser(UserDTO UserDTO)
        {
            if (UserDTO != null)
            {
                _dbOperation.Users.Update(
                    _mapper.Map<User>(UserDTO));
                await _dbOperation.SaveAsync();
            }
        }

        public UserDTO FindUserByEmail(string email)
        {
            return _mapper.Map<UserDTO>(_dbOperation.Users.FindItem(x => x.Email == email));
        }

        public UserDTO GetUser(int? id)
        {
            return _mapper.Map<UserDTO>(
                 _dbOperation.Users.GetItem(id));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _dbOperation.Users.GetItems()
                .Select(x => new UserDTO { Email = x.Email }).ToList();
        }
    }
}

using AutoMapper;
using Core.Entities;
using Data.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<UserDTO> GetUserById(int? id)
        {
            if (id != null)
            {
                return _mapper.Map<UserDTO>(
                     _dbOperation.Users.GetItem(id));
            }
            else throw new ArgumentNullException();
        }

        public async Task<int> GetUserByToken(string token)
        {
            var userList = await _dbOperation.Users.GetAllAsync();
            foreach (var item in userList)
            {
                if (item.Token == token)
                    return item.Id;
            }
            return 0;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return _mapper.Map<List<UserDTO>>(
                await _dbOperation.Users.GetAllAsync());
        }
    }
}

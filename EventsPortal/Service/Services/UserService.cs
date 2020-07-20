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
    public class UserService // :IUserService
    {
        //private readonly IUnitOfWork _dbOperation;
        //private readonly IMapper _mapper;

        //public UserService(
        //    IUnitOfWork uow,
        //    IMapper mapper)
        //{
        //    _dbOperation = uow;
        //    _mapper = mapper;
        //}

        //public async Task AddUser(UserDTO UserDTO)
        //{
        //    if (UserDTO != null)
        //    {
        //        _dbOperation.Users.Create(
        //           _mapper.Map<User>(UserDTO));
        //        await _dbOperation.Save();
        //    }
        //}

        //public async Task DeleteUser(int? id)
        //{
        //    if (id != null)
        //    {
        //        var searchItem = await _dbOperation.Users.GetIdAsync(id);

        //        if (searchItem != null)
        //        {
        //            _dbOperation.Users.Delete(searchItem);
        //            await _dbOperation.Save();
        //        }
        //    }
        //}

        //public async Task EditUser(UserDTO UserDTO)
        //{
        //    if (UserDTO != null)
        //    {
        //        _dbOperation.Users.Update(
        //            _mapper.Map<User>(UserDTO));
        //        await _dbOperation.Save();
        //    }
        //}

        //public async Task<UserDTO> GetUserById(int? id)
        //{
        //    if (id != null)
        //    {
        //        return _mapper.Map<UserDTO>(await _dbOperation.Users.GetIdAsync(id));
        //    }
        //    else throw new ArgumentNullException();
        //}

        //public async Task<IEnumerable<UserDTO>> GetUsers()
        //{
        //    return _mapper.Map<List<UserDTO>>(await _dbOperation.Users.GetAllAsync());
        //}
    }
}
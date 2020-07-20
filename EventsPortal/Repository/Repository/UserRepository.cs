using AutoMapper;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IRepository<UserDTO>
    {
        private readonly EventsPortalDbContext _dbContext;
        private IMapper _mapper;

        public UserRepository(EventsPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(UserDTO item)
        {
            if (item != null)
            {
                _dbContext.Users.Add(_mapper.Map<User>(item));
            }
            else throw new ArgumentNullException();
        }

        public void Delete(UserDTO item)
        {
            if (item != null)
            {
                _dbContext.Users.Remove(_mapper.Map<User>(item));
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return await _dbContext.Users
                .Select(x => new UserDTO
                {
                    Id = x.Id,
                    AvatarImageURI = x.AvatarImageURI,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Login = x.Login,
                    Password = x.Password,
                    UserRoleId = x.UserRoleId,
                    UserRoleDTO = new UserRoleDTO
                    {
                        Name = x.UserRole.Name
                    }
                })
                .ToListAsync();
        }

        public async Task<UserDTO> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Users
                    .Select(x => new UserDTO
                    {
                        Id = x.Id,
                        AvatarImageURI = x.AvatarImageURI,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Login = x.Login,
                        Password = x.Password,
                        UserRoleId = x.UserRoleId,
                        UserRoleDTO = new UserRoleDTO
                        {
                            Name = x.UserRole.Name
                        }
                    })
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            }
            else throw new ArgumentNullException();
        }

        public void Update(UserDTO item)
        {
            if (item != null)
            {
                _dbContext.Entry(_mapper.Map<User>(item)).State = EntityState.Modified;
            }
            else throw new ArgumentNullException();
        }
    }
}

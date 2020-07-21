using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly EventsPortalDbContext _dbContext;

        public UserRepository(EventsPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(User item)
        {
            if (item != null)
            {
                _dbContext.Users.Add(item);
            }
            else throw new ArgumentNullException();
        }

        public void Delete(User item)
        {
            if (item != null)
            {
                _dbContext.Users.Remove(item);
            }
        }

        public User FindItem(Func<User, bool> item)
        {
            if (item != null)
            {
                return _dbContext.Users.Where(item).FirstOrDefault();
            }
            else throw new ArgumentNullException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Select(x => new User
                {
                    Id = x.Id,
                    AvatarImageURI = x.AvatarImageURI,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Login = x.Login,
                    Password = x.Password,
                    UserRoleId = x.UserRoleId,
                    UserRole = new UserRole
                    {
                        Id = x.UserRole.Id,
                        Name = x.UserRole.Name
                    }
                })
                .ToListAsync();
        }

        public async Task<User> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Users
                    .Select(x => new User
                    {
                        Id = x.Id,
                        AvatarImageURI = x.AvatarImageURI,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Login = x.Login,
                        Password = x.Password,
                        UserRoleId = x.UserRoleId,
                        UserRole = new UserRole
                        {
                            Id = x.UserRole.Id,
                            Name = x.UserRole.Name
                        }
                    })
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            }
            else throw new ArgumentNullException();
        }

        public void Update(User item)
        {
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            else throw new ArgumentNullException();
        }
    }
}

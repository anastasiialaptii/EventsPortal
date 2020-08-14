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
                    IdToken = x.IdToken,
                    Email = x.Email,
                    Image = x.Image,
                    Name = x.Name,
                    Provider = x.Provider,
                    Token = x.Token
                })
                .ToListAsync();
        }

        public async Task<User> GetItem(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Users
                .Select(x => new User
                {
                    Id = x.Id,
                    IdToken = x.IdToken,
                    Email = x.Email,
                    Image = x.Image,
                    Name = x.Name,
                    Provider = x.Provider,
                    Token = x.Token
                })
                    .FirstOrDefaultAsync();
            }
            else throw new ArgumentNullException();
        }

        public IQueryable<User> GetItems()
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            else throw new ArgumentNullException();
        }

        User IRepository<User>.GetItem(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

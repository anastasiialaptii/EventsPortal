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
            var deleteItem = _dbContext.Users.Find(item.Id);

            if (deleteItem != null)
            {
                _dbContext.Users.Remove(deleteItem);
            }
        }

        public User FindItemAsync(Func<User, bool> item)
        {
            return _dbContext.Users
                .Where(item)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(x => x.UserRole)
                .ToListAsync();
        }

        public async Task<User> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Users.FindAsync(id);
            }
            else throw new ArgumentNullException();
        }

        public object GetList()
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
    }
}

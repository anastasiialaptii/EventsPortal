using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Linq;

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

        public IQueryable<User> GetItems()
        {
            return _dbContext.Users;
        }

        public void Update(User item)
        {
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            else throw new ArgumentNullException();
        }

        public User GetItem(int? id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

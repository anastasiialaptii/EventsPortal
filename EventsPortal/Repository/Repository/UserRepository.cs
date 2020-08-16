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
            _dbContext.Users.Add(item);
        }

        public void Delete(User item)
        {
            _dbContext.Users.Remove(item);
        }

        public User FindItem(Func<User, bool> item)
        {
            return _dbContext.Users.Where(item).FirstOrDefault();
        }

        public IQueryable<User> GetItems()
        {
            return _dbContext.Users;
        }

        public void Update(User item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public User GetItem(int? id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

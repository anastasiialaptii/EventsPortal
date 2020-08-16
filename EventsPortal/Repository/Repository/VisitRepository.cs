using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Linq;

namespace Data.Repository
{
    public class VisitRepository : IRepository<Visit>
    {
        private readonly EventsPortalDbContext _dbContext;

        public VisitRepository(EventsPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Visit item)
        {
            _dbContext.Visits.Add(item);
        }

        public void Delete(Visit item)
        {
            _dbContext.Visits.Remove(item);
        }

        public Visit FindItem(Func<Visit, bool> item)
        {
            return _dbContext.Visits
                 .Where(item)
                 .FirstOrDefault();
        }

        public Visit GetItem(int? id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Visit> GetItems()
        {
            return _dbContext.Visits;
        }

        public void Update(Visit item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}

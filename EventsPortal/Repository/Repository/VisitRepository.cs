using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (item != null)
            {
                _dbContext.Visits.Add(item);
            }
            else throw new ArgumentNullException();
        }

        public void Delete(Visit item)
        {
            if (item != null)
            {
                _dbContext.Visits.Remove(item);
            }
            else throw new ArgumentNullException();
        }

        public Visit FindItem(Func<Visit, bool> item)
        {
            return _dbContext.Visits
                 .Where(item)
                 .FirstOrDefault();
        }

        public async Task<IEnumerable<Visit>> GetAllAsync()
        {
            return await _dbContext.Visits.ToListAsync();
        }

        public async Task<Visit> GetIdAsync(int? id)
        {
            if (id != null)
            {
                var searchItem = await _dbContext.Visits.FindAsync(id);

                if (searchItem != null)
                    return searchItem;
                else throw new ArgumentNullException();
            }
            else throw new ArgumentNullException();
        }

        public object GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Visit item)
        {
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            else throw new ArgumentNullException();
        }
    }
}

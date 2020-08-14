using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Linq;

namespace Data.Repository
{
    public class EventRepository : IRepository<Event>
    {
        private readonly EventsPortalDbContext _dbContext;

        public EventRepository(EventsPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Event item)
        {
            if (item != null)
            {
                _dbContext.Events.Add(item);
            }
        }

        public void Delete(Event item)
        {
            if (item != null)
            {
                _dbContext.Events.Remove(item);
            }
        }

        public Event FindItem(Func<Event, bool> item)
        {
            if (item != null)
            {
                return _dbContext.Events.Where(item).FirstOrDefault();
            }
            else throw new ArgumentNullException();
        }

        public Event GetItem(int? id)
        {
            return _dbContext.Events.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Event> GetItems()
        {
            return _dbContext.Events;
        }

        public void Update(Event item)
        {
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
        }
    }
}

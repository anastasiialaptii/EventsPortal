using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var deleteItem = _dbContext.Events.Find(item.Id);

            if (deleteItem != null)
            {
                _dbContext.Events.Remove(deleteItem);
            }
        }

        public Event FindItemAsync(Func<Event, bool> item)
        {
            if (item != null)
            {
                return _dbContext.Events
                    .Where(item)
                    .FirstOrDefault();
            }
            else throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
           return await _dbContext.Events
                .Include(x=>x.Organizer)
                .ToListAsync();
        }

        public async Task<Event> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Events.FindAsync(id);
            }
            else throw new ArgumentNullException();
        }

        public void Update(Event item)
        {
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
        }

        public Object GetList()
        {
            var result = (from a in _dbContext.Events
                          join b in _dbContext.Users on a.OrganizerId equals b.Id

                          select new
                          {
                              a.Id,
                              a.Name,
                              Organizer = b.LastName,
                              a.Location,
                              a.ImageURI
                          }).ToList();

            //var result1 = _dbContext.Events.Join(_dbContext.Users,
            // p => p.OrganizerId, 
            // t => t.Id, 
            // (p, t) => new { Name = p.Location, Team = p.Name, Country = t.FirstName });

            return result;
        }
    }
}

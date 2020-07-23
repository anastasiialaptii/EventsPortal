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

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _dbContext.Events
                .Select(x => new Event
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    ImageURI = x.ImageURI,
                    Description = x.Description,
                    OrganizerId = x.OrganizerId,
                    EventTypeId = x.EventTypeId,
                    Organizer = new User
                    {
                        Id = x.Organizer.Id,
                        Name = x.Organizer.Name
                    },
                    EventType = new EventType
                    {
                        Id = x.EventType.Id,
                        Name = x.EventType.Name
                    }
                })
                .ToListAsync();
        }

        public async Task<Event> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Events
                .Select(x => new Event
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    ImageURI = x.ImageURI,
                    Description = x.Description,
                    OrganizerId = x.OrganizerId,
                    EventTypeId = x.EventTypeId,
                    Organizer = new User
                    {
                        Id = x.Organizer.Id,
                        Name = x.Organizer.Name
                    },
                    EventType = new EventType
                    {
                        Id = x.EventType.Id,
                        Name = x.EventType.Name
                    }
                })
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();
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
    }
}

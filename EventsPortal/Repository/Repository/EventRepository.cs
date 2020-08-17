using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.IO;
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
                File.Delete(item.ImageURI);
                _dbContext.Events.Remove(item);
            }
        }

        public Event FindItem(Func<Event, bool> item)
        {
            return _dbContext.Events.Where(item).FirstOrDefault();
        }

        public Event GetItem(int? id)
        {
            return _dbContext.Events.Where(x => x.Id == id)
                .Select(x => new Event
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    ImageURI = x.ImageURI,
                    Description = x.Description,
                    Date = x.Date,
                    OrganizerId = x.OrganizerId,
                    EventTypeId = x.EventTypeId,
                    Organizer = new User
                    {
                        Id = x.Organizer.Id,
                        Name = x.Organizer.Name,
                        Email = x.Organizer.Email
                    },
                    EventType = new EventType
                    {
                        Id = x.EventType.Id,
                        Name = x.EventType.Name
                    }
                }).FirstOrDefault();
        }

        public IQueryable<Event> GetItems()
        {
            return _dbContext.Events;
        }

        public void Update(Event item)
        {
            if (item.ImageURI != _dbContext.Events.Find(item.Id).ImageURI)
            {
                File.Delete(_dbContext.Events.Find(item.Id).ImageURI);
            }
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}

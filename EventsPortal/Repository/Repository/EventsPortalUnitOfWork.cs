using Core.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EventsPortalUnitOfWork : IUnitOfWork
    {
        private readonly EventsPortalDbContext _dbContext;

        private EventRepository eventRepository;

        public EventsPortalUnitOfWork(DbContextOptions<EventsPortalDbContext> options)
        {
            _dbContext = new EventsPortalDbContext(options);
        }

        public IRepository<Event> Events
        {
            get
            {
                if (eventRepository == null)
                    eventRepository = new EventRepository(_dbContext);
                return eventRepository;
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

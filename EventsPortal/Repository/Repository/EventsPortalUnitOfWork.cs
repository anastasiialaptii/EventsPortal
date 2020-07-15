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

        private EventTypeRepository eventTypeRepository;

        public EventsPortalUnitOfWork(DbContextOptions<EventsPortalDbContext> options)
        {
            _dbContext = new EventsPortalDbContext(options);
        }

        public IRepository<EventType> EventTypes
        {
            get
            {
                if (eventTypeRepository == null)
                    eventTypeRepository = new EventTypeRepository(_dbContext);
                return eventTypeRepository;
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

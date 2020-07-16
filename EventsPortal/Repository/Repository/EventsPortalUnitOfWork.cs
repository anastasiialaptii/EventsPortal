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
        private UserRepository userRepository;
        private VisitRepository visitRepository;

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

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_dbContext);
                return userRepository;
            }
        }

        public IRepository<Visit> Visits
        {
            get
            {
                if (visitRepository == null)
                    visitRepository = new VisitRepository(_dbContext);
                return visitRepository;
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.DTO;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EventsPortalUnitOfWork : IUnitOfWork
    {
        private readonly EventsPortalDbContext _dbContext;
        private IMapper _mapper;

        private EventRepository eventRepository;
        private UserRepository userRepository;
        //private VisitRepository visitRepository;

        public EventsPortalUnitOfWork(DbContextOptions<EventsPortalDbContext> options, IMapper mapper)
        {
            _dbContext = new EventsPortalDbContext(options);
            _mapper = mapper;
        }

        public IRepository<EventDTO> Events
        {
            get
            {
                if (eventRepository == null)
                    eventRepository = new EventRepository(_dbContext, _mapper);
                return eventRepository;
            }
        }

        public IRepository<UserDTO> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_dbContext, _mapper);
                return userRepository;
            }
        }

        //public IRepository<VisitDTO> Visits
        //{
        //    get
        //    {
        //        if (visitRepository == null)
        //            visitRepository = new VisitRepository(_dbContext);
        //        return visitRepository;
        //    }
        //}

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

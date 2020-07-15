using Core.Entities;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class EventTypeRepository : IRepository<EventType>
    {
        private EventsPortalDbContext _dbContext;

        public EventTypeRepository(EventsPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<EventType> GetAllAsync()
        {
            return _dbContext.EventTypes.ToList();
        }
    }
}

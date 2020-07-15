using Core.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EventTypeRepository : IRepository<EventType>
    {
        private readonly EventsPortalDbContext _dbContext;

        public EventTypeRepository(EventsPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(EventType item)
        {
            throw new NotImplementedException();
        }

        public void Delete(EventType item)
        {
            throw new NotImplementedException();
        }

        public Task<EventType> FindItemAsync(Func<EventType, bool> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventType> GetAllAsync()
        {
            return _dbContext.EventTypes.ToList();
        }

        public Task<EventType> GetIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(EventType item)
        {
            throw new NotImplementedException();
        }
    }
}

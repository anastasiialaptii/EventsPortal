using Core.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EventRepository : IRepository<Event>
    {
        //private readonly EventsPortalDbContext _dbContext;
       
        public void Create(Event item)
        {
            if (item != null)
            {
                //_dbContext.Add(item);
            }
        }

        public void Delete(Event item)
        {
            throw new NotImplementedException();
        }

        public Task<Event> FindItemAsync(Func<Event, bool> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Event item)
        {
            throw new NotImplementedException();
        }
    }
}

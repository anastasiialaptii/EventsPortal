﻿using Core.Entities;
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
            else throw new ArgumentNullException();
        }

        public void Delete(Event item)
        {
            var deleteItem = _dbContext.Events.Find(item.Id);

            if (deleteItem != null)
            {
                _dbContext.Events.Remove(deleteItem);
            }
            else throw new ArgumentNullException();
        }

        public Event FindItemAsync(Func<Event, bool> item)
        {
            return _dbContext.Events
                .Where(item)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _dbContext.Events
                .ToListAsync();
        }

        public async Task<Event> GetIdAsync(int? id)
        {
            if (id != null)
            {
                var searchItem = await _dbContext.Events.FindAsync(id);

                if (searchItem != null)
                    return searchItem;
                else throw new ArgumentNullException();
            }
            else throw new ArgumentNullException();
        }

        public void Update(Event item)
        {
            if (item != null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            else throw new ArgumentNullException();
        }
    }
}

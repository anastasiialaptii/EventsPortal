using AutoMapper;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EventRepository : IRepository<EventDTO>
    {
        private readonly EventsPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventRepository(EventsPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(EventDTO item)
        {
            if (item != null)
            {
                _dbContext.Events.Add(_mapper.Map<Event>(item));
            }
        }

        public void Delete(EventDTO item)
        {
            _dbContext.Events.Remove(_mapper.Map<Event>(item));
        }

        public async Task<IEnumerable<EventDTO>> GetAllAsync()
        {
            return await _dbContext.Events
                .Select(x => new EventDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    ImageURI = x.ImageURI,
                    Description = x.Description,
                    OrganizerId = x.OrganizerId,
                    EventTypeId = x.EventTypeId,
                    UserDTO = new UserDTO { Login = x.Organizer.Login },
                    EventTypeDTO = new EventTypeDTO { Name = x.EventType.Name }
                }).ToListAsync();
        }

        public async Task<EventDTO> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Events.Where(x => x.Id == id)
                .Select(x => new EventDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    ImageURI = x.ImageURI,
                    Description = x.Description,
                    OrganizerId = x.OrganizerId,
                    EventTypeId = x.EventTypeId,
                    UserDTO = new UserDTO { Login = x.Organizer.Login },
                    EventTypeDTO = new EventTypeDTO { Name = x.EventType.Name }
                }).FirstOrDefaultAsync();
            }
            else throw new ArgumentNullException();
        }

        public void Update(EventDTO item)
        {
            if (item != null)
            {
                _dbContext.Entry(_mapper.Map<Event>(item)).State = EntityState.Modified;
            }
        }
    }
}

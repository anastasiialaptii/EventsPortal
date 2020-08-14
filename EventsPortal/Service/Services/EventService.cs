using AutoMapper;
using Core.Entities;
using Data.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;

        public EventService(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public async Task AddEvent(EventDTO eventDTO)
        {
            if (eventDTO != null)
            {
                _dbOperation.Events.Create(
                    _mapper.Map<Event>(eventDTO));
                await _dbOperation.SaveAsync();
            }
        }

        public async Task DeleteEvent(int? id)
        {
            if (id != null)
            {
                var searchItem = _dbOperation.Events.GetItem(id);

                if (searchItem != null)
                {
                    _dbOperation.Events.Delete(searchItem);
                    await _dbOperation.SaveAsync();
                }
            }
        }

        public async Task EditEvent(EventDTO eventDTO)
        {
            if (eventDTO != null)
            {
                _dbOperation.Events.Update(
                    _mapper.Map<Event>(eventDTO));
                await _dbOperation.SaveAsync();
            }
        }

        public EventDTO GetEvent(int? id)
        {
            return _mapper.Map<EventDTO>(
                _dbOperation.Events.GetItem(id));
        }

        public IEnumerable<EventDTO> GetEvents()
        {
            return _mapper.Map<List<EventDTO>>(
                _dbOperation.Events.GetItems()
                .Select(x => new EventDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    ImageURI = x.ImageURI,
                    Description = x.Description,
                    Date = x.Date,
                    OrganizerId = x.OrganizerId,
                    EventTypeId = x.EventTypeId,
                    Organizer = new UserDTO
                    {
                        Id = x.Organizer.Id,
                        Name = x.Organizer.Name,
                        Email = x.Organizer.Email
                    },
                    EventType = new EventTypeDTO
                    {
                        Id = x.EventType.Id,
                        Name = x.EventType.Name
                    }
                }).ToList());
        }

        public IEnumerable<EventDTO> GetPublicEvents()
        {
            return _dbOperation.Events.GetItems()
               .Where(x => x.EventType.Name == "Public")
               .Select(x => new EventDTO
               {
                   Id = x.Id,
                   Name = x.Name,
                   Location = x.Location,
                   ImageURI = x.ImageURI,
                   Description = x.Description,
                   Date = x.Date,
                   OrganizerId = x.OrganizerId,
                   EventTypeId = x.EventTypeId,
                   Organizer = new UserDTO
                   {
                       Id = x.Organizer.Id,
                       Name = x.Organizer.Name,
                       Email = x.Organizer.Email
                   },
                   EventType = new EventTypeDTO
                   {
                       Id = x.EventType.Id,
                       Name = x.EventType.Name
                   }
               }).ToList();
        }

        public IEnumerable<EventDTO> GetPublicOwnEvents(string userId)
        {
            return _dbOperation.Events.GetItems()
              .Where(x => x.EventType.Name == "Public" || x.EventType.Name == "Private" && x.Organizer.Email == userId)
              .Select(x => new EventDTO
              {
                  Id = x.Id,
                  Name = x.Name,
                  Location = x.Location,
                  ImageURI = x.ImageURI,
                  Description = x.Description,
                  Date = x.Date,
                  OrganizerId = x.OrganizerId,
                  EventTypeId = x.EventTypeId,
                  Organizer = new UserDTO
                  {
                      Id = x.Organizer.Id,
                      Name = x.Organizer.Name,
                      Email = x.Organizer.Email
                  },
                  EventType = new EventTypeDTO
                  {
                      Id = x.EventType.Id,
                      Name = x.EventType.Name
                  }
              }).ToList();
        }

        public IEnumerable<EventDTO> SearchEvents(string userId, string eventName)
        {
            return _dbOperation.Events.GetItems()
                .Where(x => x.EventType.Name == "Public" || x.EventType.Name == "Private" && x.Organizer.Email == userId)
                .Where(x => x.Name.Contains(eventName))
                .Select(x => new EventDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    ImageURI = x.ImageURI,
                    Description = x.Description,
                    Date = x.Date,
                    OrganizerId = x.OrganizerId,
                    EventTypeId = x.EventTypeId,
                    Organizer = new UserDTO
                    {
                        Id = x.Organizer.Id,
                        Name = x.Organizer.Name,
                        Email = x.Organizer.Email
                    },
                    EventType = new EventTypeDTO
                    {
                        Id = x.EventType.Id,
                        Name = x.EventType.Name
                    }
                }).ToList();
        }

        //public List<int> IsEventUserCreated(string userId)
        //{
        //    var eventVisitorsList = 
        //        _dbOperation.Visits.GetItems()
        //         .Where(x => x.User.Email == userId)
        //         .Select(x => new VisitDTO { EventId = x.EventId })
        //         .ToList();

        //    //var events = _mapper.Map<List<EventDTO>>(
        //    //    _dbOperation.Events.GetItems()).ToList();

        //    var visitEvent = new List<int>();

        //    foreach (var item in eventVisitorsList)
        //    {
        //        if (item.User.Token == userId)
        //            visitEvent.Add(item.EventId);
        //    }

        //    var eventsIdList = new List<int>();

        //    foreach (var item in events)
        //    {
        //        eventsIdList.Add(item.Id);
        //    }

        //    return eventsIdList.Except<int>(visitEvent).ToList();
        //}
    }
}

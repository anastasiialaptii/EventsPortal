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
            return _mapper.Map<List<EventDTO>>(
                _dbOperation.Events.GetItems()
                .Where(x=>x.EventType.Name=="Public")
                .Select(x => new EventDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    ImageURI = x.ImageURI,
                    Description = x.Description,
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
        //IEnumerable<EventDTO> IEventService.GetEvent(int? id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public async Task<IEnumerable<EventDTO>> GetAllowedEventList(string organizerId, string searchEvent)
        //{
        //    var events = _mapper.Map<List<EventDTO>>(
        //        await _dbOperation.Events.GetAllAsync());

        //    var allowedEventList = new List<EventDTO>();

        //    if (organizerId != null && searchEvent != null)
        //    {
        //        foreach (var item in events)
        //        {
        //            if ((item.EventType.Name == "Public" || item.Organizer.Token == organizerId) && item.Name.Contains(searchEvent))
        //                allowedEventList.Add(item);
        //        }
        //        return allowedEventList;
        //    }
        //    else if (organizerId != null && searchEvent == null)
        //    {
        //        foreach (var item in events)
        //        {
        //            if (item.EventType.Name == "Public" || item.Organizer.Token == organizerId)
        //                allowedEventList.Add(item);
        //        }
        //        return allowedEventList;
        //    }

        //    else if (organizerId == null && searchEvent == null)
        //    {
        //        foreach (var item in events)
        //        {
        //            if (item.EventType.Name == "Public")
        //                allowedEventList.Add(item);
        //        }
        //        return allowedEventList;
        //    }
        //    return new List<EventDTO>() { new EventDTO { Description = "none" } };
        //}

        //public async Task<IEnumerable<EventDTO>> GetSearchedEventList(string searchEvent)
        //{
        //    var events = _mapper.Map<List<EventDTO>>(
        //        await _dbOperation.Events.GetAllAsync());

        //    var searchedEventList = new List<EventDTO>();
        //    foreach (var item in events)
        //    {
        //        if (item.Name.Contains(searchEvent))
        //            searchedEventList.Add(item);
        //    }
        //    return searchedEventList;
        //}

        //public async Task<List<int>> IsEventUserCreated(string userId)
        //{
        //    var eventVisitorsList = _mapper.Map<List<VisitDTO>>(
        //        await _dbOperation.Visits.GetAllAsync());

        //    var events = _mapper.Map<List<EventDTO>>(
        //        await _dbOperation.Events.GetAllAsync());

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

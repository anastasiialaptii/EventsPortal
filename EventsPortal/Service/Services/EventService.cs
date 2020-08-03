using AutoMapper;
using Core.Entities;
using Data.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
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
                var searchItem = await _dbOperation.Events.GetIdAsync(id);

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

        public async Task<IEnumerable<EventDTO>> GetEventById(int? id)
        {
            var events = _mapper.Map<List<EventDTO>>(
                await _dbOperation.Events.GetAllAsync());

            var eventByIdList = new List<EventDTO>();
            foreach (var item in events)
            {
                if (item.Id == id)
                    eventByIdList.Add(item);
            }
            return eventByIdList;
        }

        public async Task<IEnumerable<EventDTO>> GetEvents()
        {
            return _mapper.Map<List<EventDTO>>(
                await _dbOperation.Events.GetAllAsync());
        }

        public async Task<IEnumerable<EventDTO>> GetAllowedEventList(string organizerId, string searchEvent)
        {
            var events = _mapper.Map<List<EventDTO>>(
                await _dbOperation.Events.GetAllAsync());

            var allowedEventList = new List<EventDTO>();

            if (organizerId != null && searchEvent != null)
            {
                foreach (var item in events)
                {
                    if ((item.EventType.Name == "Public" || item.Organizer.Token == organizerId) && item.Name.Contains(searchEvent))
                        allowedEventList.Add(item);
                }
                return allowedEventList;
            }
            else if (organizerId != null && searchEvent == null)
            {
                foreach (var item in events)
                {
                    if (item.EventType.Name == "Public" || item.Organizer.Token == organizerId)
                        allowedEventList.Add(item);
                }
                return allowedEventList;
            }

            else if (organizerId == null && searchEvent == null)
            {
                foreach (var item in events)
                {
                    if (item.EventType.Name == "Public")
                        allowedEventList.Add(item);
                }
                return allowedEventList;
            }
            return new List<EventDTO>() { new EventDTO { Description = "none" } };
        }

        public async Task<IEnumerable<EventDTO>> GetSearchedEventList(string searchEvent)
        {
            var events = _mapper.Map<List<EventDTO>>(
                await _dbOperation.Events.GetAllAsync());

            var searchedEventList = new List<EventDTO>();
            foreach (var item in events)
            {
                if (item.Name.Contains(searchEvent))
                    searchedEventList.Add(item);
            }
            return searchedEventList;
        }
    }
}

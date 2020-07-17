using AutoMapper;
using Core.Entities;
using Data.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System;
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
                await _dbOperation.Save();
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
                    await _dbOperation.Save();
                }
            }
        }

        public async Task EditEvent(EventDTO eventDTO)
        {
            if (eventDTO != null)
            {
                _dbOperation.Events.Update(
                    _mapper.Map<Event>(eventDTO));
                await _dbOperation.Save();
            }
        }

        public async Task<EventDTO> GetEventById(int? id)
        {
            if (id != null)
            {
                return _mapper.Map<EventDTO>(await _dbOperation.Events.GetIdAsync(id));
            }
            else throw new ArgumentNullException();
        }

        public async Task<IEnumerable<EventDTO>> GetEvents()
        {
            return _mapper.Map<List<EventDTO>>(await _dbOperation.Events.GetAllAsync());
        }

        public object GetList()
        {
            return _dbOperation.Events.GetList();
        }
    }
}
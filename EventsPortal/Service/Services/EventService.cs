using AutoMapper;
using Data.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<EventDTO>> GetEvents()
        {
            return _mapper.Map<List<EventDTO>>(await _dbOperation.Events.GetAllAsync());
        }
    }
}

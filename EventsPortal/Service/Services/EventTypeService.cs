using AutoMapper;
using Core.Entities;
using Data.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class EventTypeService : IEventsTypeService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;

        public EventTypeService(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public IEnumerable<EventTypeDTO> GetEventsType()
        {
            return _mapper.Map<List<EventTypeDTO>>( _dbOperation.EventTypes.GetAllAsync());
        }
    }
}

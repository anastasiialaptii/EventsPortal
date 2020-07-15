using Core.Entities;
using Data.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class EventTypeService : IEventsTypeService
    {
        private readonly IUnitOfWork _dbOperation;

        public EventTypeService(
            IUnitOfWork uow)
        {
            _dbOperation = uow;
        }

        public IEnumerable<EventType> GetEventsType()
        {
            return _dbOperation.EventTypes.GetAllAsync();
        }
    }
}

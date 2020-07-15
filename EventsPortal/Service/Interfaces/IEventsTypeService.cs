using Core.Entities;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IEventsTypeService
    {
        IEnumerable<EventType> GetEventsType();
    }
}

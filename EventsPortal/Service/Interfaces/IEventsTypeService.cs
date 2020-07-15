using Core.Entities;
using Service.DTO;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IEventsTypeService
    {
        IEnumerable<EventTypeDTO> GetEventsType();
    }
}

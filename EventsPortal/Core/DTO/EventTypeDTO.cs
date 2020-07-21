using Core.DTO;
using System.Collections.Generic;

namespace Service.DTO
{
    public class EventTypeDTO : BaseEntityDTO
    {
        public string Name { get; set; }

        public IEnumerable<EventDTO> EventsDTO { get; set; }
    }
}

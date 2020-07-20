using System.Collections.Generic;

namespace Service.DTO
{
    public class EventTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<EventDTO> EventsDTO { get; set; }
    }
}

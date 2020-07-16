using System.Collections.Generic;

namespace Service.DTO
{
    public class EventTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<EventDTO> EventsDTO { get; set; }
    }
}

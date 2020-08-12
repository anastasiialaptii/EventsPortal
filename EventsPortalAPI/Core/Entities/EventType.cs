using Core.DTO;
using System.Collections.Generic;

namespace Core.Entities
{
    public class EventType : BaseEntityDTO
    {
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

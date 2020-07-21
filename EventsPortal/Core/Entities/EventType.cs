using System.Collections.Generic;

namespace Core.Entities
{
    public class EventType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

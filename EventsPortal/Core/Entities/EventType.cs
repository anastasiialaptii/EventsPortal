using System.Collections.Generic;

namespace Core.Entities
{
    public class EventType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

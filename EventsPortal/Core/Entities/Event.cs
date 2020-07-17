using System.Collections.Generic;

namespace Core.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string ImageURI { get; set; }

        public int EventTypeId { get; set; }

        public int OrganizerId { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual User Organizer { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}

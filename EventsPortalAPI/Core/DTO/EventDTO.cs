using System;

namespace Core.DTO
{
    public class EventDTO : BaseEntityDTO
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string ImageURI { get; set; }

        public DateTimeOffset Date { get; set; }

        public int EventTypeId { get; set; }

        public int OrganizerId { get; set; }

        public UserDTO Organizer { get; set; }

        public EventTypeDTO EventType { get; set; }
    }
}

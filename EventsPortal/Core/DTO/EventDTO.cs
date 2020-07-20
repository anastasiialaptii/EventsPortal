using System.Collections.Generic;

namespace Service.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string ImageURI { get; set; }

        public int EventTypeId { get; set; }

        public int OrganizerId { get; set; }

        public UserDTO UserDTO { get; set; }

        public EventTypeDTO EventTypeDTO { get; set; }

        public IEnumerable<VisitDTO> VisitsDTO { get; set; }
    }
}

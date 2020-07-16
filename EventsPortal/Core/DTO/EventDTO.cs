using System.Collections.Generic;

namespace Service.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Descriprion { get; set; }

        public string Image { get; set; }

        public EventTypeDTO EventTypeDTO { get; set; }

        public UserDTO OrganizerDTO { get; set; }

        public ICollection<VisitDTO> VisitsDTO { get; set; }
    }
}

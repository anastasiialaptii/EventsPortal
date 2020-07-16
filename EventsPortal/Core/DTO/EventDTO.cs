using System.Collections.Generic;

namespace Service.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Descriprion { get; set; }

        public string ImageURI { get; set; }

        public int EventTypeId { get; set; }

        public int OrganizerId { get; set; }

        public virtual EventTypeDTO EventTypeDTO { get; set; }

        public virtual UserDTO OrganizerDTO { get; set; }

        public virtual ICollection<VisitDTO> VisitsDTO { get; set; }
    }
}

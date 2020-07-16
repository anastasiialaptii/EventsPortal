using System.Collections.Generic;

namespace EventsPortal.ViewModel
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
        
        public string Descriprion { get; set; }

        public string ImageURI { get; set; }

        public int EventTypeId { get; set; }

        public int OrganizerId { get; set; }

        public virtual EventTypeViewModel EventTypeViewModel { get; set; }

        public virtual UserViewModel OrganizerViewModel { get; set; }

        public virtual ICollection<VisitViewModel> VisitsViewModel { get; set; }
    }
}

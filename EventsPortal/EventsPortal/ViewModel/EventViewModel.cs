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

        public EventTypeViewModel EventTypeViewModel { get; set; }

        public UserViewModel OrganizerViewModel { get; set; }

        public ICollection<VisitViewModel> VisitsViewModel { get; set; }
    }
}

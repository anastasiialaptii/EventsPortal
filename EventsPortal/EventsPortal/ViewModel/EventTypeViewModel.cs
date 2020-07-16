using System.Collections.Generic;

namespace EventsPortal.ViewModel
{
    public class EventTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<EventViewModel> EventsViewModel { get; set; }
    }
}

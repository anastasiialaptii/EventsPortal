namespace EventsPortal.ViewModel
{
    public class VisitViewModel
    {
        public int EventId { get; set; }

        public EventViewModel EventViewModel { get; set; }

        public int UserId { get; set; }

        public UserViewModel UserViewModel { get; set; }
    }
}

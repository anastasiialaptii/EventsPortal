namespace EventsPortal.ViewModel
{
    public class VisitViewModel
    {
        public int EventId { get; set; }

        public virtual EventViewModel EventViewModel { get; set; }

        public int UserId { get; set; }

        public virtual UserViewModel UserViewModel { get; set; }
    }
}

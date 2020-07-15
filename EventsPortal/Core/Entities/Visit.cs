namespace Core.Entities
{
    public class Visit
    {
        public int EventId { get; set; }

        public Event Event { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}

namespace Service.DTO
{
    public class VisitDTO
    {
        public int EventId { get; set; }

        public EventDTO Event { get; set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }
    }
}

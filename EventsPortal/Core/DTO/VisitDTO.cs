namespace Service.DTO
{
    public class VisitDTO
    {
        public int EventId { get; set; }

        public EventDTO EventDTO { get; set; }

        public int UserId { get; set; }

        public UserDTO UserDTO { get; set; }
    }
}

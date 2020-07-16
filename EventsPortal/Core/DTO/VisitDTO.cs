namespace Service.DTO
{
    public class VisitDTO
    {
        public int EventId { get; set; }

        public virtual EventDTO EventDTO { get; set; }

        public int UserId { get; set; }

        public virtual UserDTO UserDTO { get; set; }
    }
}

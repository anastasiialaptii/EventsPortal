using System.Collections.Generic;

namespace Core.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Descriprion { get; set; }

        public byte[] Image { get; set; }

        public EventType EventType { get; set; }

        public User User { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}

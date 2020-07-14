using System.Collections.Generic;

namespace DAL.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] EventImage { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public ICollection<EventUser> EventUser { get; set; }
    }
}

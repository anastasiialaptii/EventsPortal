using System.Collections.Generic;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string GoogleId { get; set; }

        public string Email { get; set; }

        public string IdToken { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string Provider { get; set; }

        public string Token { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

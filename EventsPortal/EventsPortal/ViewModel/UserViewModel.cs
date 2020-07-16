using System.Collections.Generic;

namespace EventsPortal.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarImageURI { get; set; }

        public int UserRoleId { get; set; }

        public virtual UserRoleViewModel UserRoleViewModel { get; set; }

        public virtual ICollection<VisitViewModel> VisitsViewModel { get; set; }

        public virtual ICollection<EventViewModel> EventsViewModel { get; set; }
    }
}

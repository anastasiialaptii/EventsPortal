using System.Collections.Generic;

namespace EventsPortal.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] AvatarImage { get; set; }

        public UserRoleViewModel UserRoleViewModel { get; set; }

        public ICollection<VisitViewModel> VisitsViewModel { get; set; }
    }
}

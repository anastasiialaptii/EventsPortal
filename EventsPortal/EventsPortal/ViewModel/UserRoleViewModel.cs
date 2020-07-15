using System.Collections.Generic;

namespace EventsPortal.ViewModel
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserViewModel> UsersViewModel { get; set; }

    }
}

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.EventsPortalContext
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasData(
                new UserRole
                {
                    Id = 1,
                    Name = "Visitor"
                },
                new UserRole
                {
                    Id = 2,
                    Name = "Organizer"
                }
                );

            modelBuilder.Entity<EventType>()
                .HasData(
                new EventType
                {
                    Id = 1,
                    Name = "Private"
                },
                new EventType
                {
                    Id = 2,
                    Name = "Public"
                });

            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Madara",
                    LastName = "Uchiha",
                    Login = "Ninja",
                    Password = "qwerty",
                    AvatarImageURI = "avatarName",
                    UserRoleId = 1
                },
                new User
                {
                    Id = 2,
                    FirstName = "Zoro",
                    LastName = "Roronoa",
                    Login = "Samurai",
                    Password = "qwerty",
                    AvatarImageURI = "avatarName",
                    UserRoleId = 2
                },
                new User
                {
                    Id = 3,
                    FirstName = "Naruto",
                    LastName = "Uzumaki",
                    Login = "Hokage",
                    Password = "qwerty",
                    AvatarImageURI = "avatarName",
                    UserRoleId = 1
                });

            modelBuilder.Entity<Event>()
                .HasData(
                new Event
                {
                    Id = 1,
                    Description = "Funny event",
                    EventTypeId = 1,
                    ImageURI = "eventImage",
                    Location = "East Blue",
                    Name = "B-day party",
                    OrganizerId = 1
                },
                 new Event
                 {
                     Id = 2,
                     Description = "Cool event",
                     EventTypeId = 1,
                     ImageURI = "eventImage",
                     Location = "West Blue",
                     Name = "Tea party",
                     OrganizerId = 1
                 },
                 new Event
                 {
                     Id = 3,
                     Description = "Awesome event",
                     EventTypeId = 2,
                     ImageURI = "eventImage",
                     Location = "South Blue",
                     Name = "Banquets",
                     OrganizerId = 1
                 });
        }
    }
}
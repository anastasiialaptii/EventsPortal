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
        }
    }
}
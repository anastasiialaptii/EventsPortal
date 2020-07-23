using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.EventsPortalContext
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
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
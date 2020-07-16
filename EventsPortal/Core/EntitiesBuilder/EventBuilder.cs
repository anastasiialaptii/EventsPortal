using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntitiesBuilder
{
    public class EventBuilder
    {
        public EventBuilder(EntityTypeBuilder<Event> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder
                .HasOne(x => x.EventType)
                .WithMany(x => x.Events);

            entityBuilder
                .HasOne(x => x.Organizer)
                .WithMany(x => x.Events)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}

using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntitiesBuilder
{
    public class EventTypeBuilder
    {
        public EventTypeBuilder(EntityTypeBuilder<EventType> entityBuilder)
        {
            entityBuilder
                .HasKey(x => x.Id);
        }
    }
}
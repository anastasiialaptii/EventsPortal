using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntitiesBuilder
{
    public class EventBuilder
    {
        public EventBuilder(EntityTypeBuilder<Event> entityBuilder)
        {
            entityBuilder
                .HasOne(x => x.User)
                .WithMany(w => w.Events);
        }
    }
}

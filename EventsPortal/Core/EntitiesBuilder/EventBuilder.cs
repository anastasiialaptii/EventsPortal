using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntitiesBuilder
{
    public class EventBuilder
    {
        public EventBuilder(EntityTypeBuilder<Event> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}

using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntitiesBuilder
{
    public class TypeBuilder
    {
        public TypeBuilder(EntityTypeBuilder<EventType> entityBuilder)
        {
            entityBuilder
                .HasKey(x => x.Id);
        }
    }
}

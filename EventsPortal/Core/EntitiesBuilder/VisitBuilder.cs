using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntitiesBuilder
{
    public class VisitBuilder
    {
        public VisitBuilder(EntityTypeBuilder<Visit> entityBuilder)
        {
            entityBuilder
                .HasKey(x => new { x.EventId, x.UserId });
            entityBuilder
                .HasOne(x => x.User)
                .WithMany(w => w.Visits)
                .HasForeignKey(x => x.UserId);
            entityBuilder
                .HasOne(x => x.Event)
                .WithMany(w => w.Visits)
                .HasForeignKey(x => x.EventId);
        }
    }
}

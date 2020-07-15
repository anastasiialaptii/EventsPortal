using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntitiesBuilder
{
    public class RoleBuilder
    {
        public RoleBuilder(EntityTypeBuilder<UserRole> entityBuilder)
        {
            entityBuilder
                .HasKey(x => x.Id);
        }
    }
}

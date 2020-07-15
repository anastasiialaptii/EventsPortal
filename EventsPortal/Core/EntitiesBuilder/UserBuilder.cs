using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntitiesBuilder
{
    public class UserBuilder
    {
        public UserBuilder(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder
                .HasOne(x => x.UserRole)
                .WithMany(x => x.Users);
        }
    }
}

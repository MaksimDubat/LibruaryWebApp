using LibruaryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibruaryAPI.Infrastructure.Configurations
{
    /// <summary>
    /// Конфигурация для сущности с AppUsersRoles.
    /// </summary>
    public class AppUsersRolesConfiguration : IEntityTypeConfiguration<AppUsersRoles>
    {
        public void Configure(EntityTypeBuilder<AppUsersRoles> builder)
        {
            builder.ToTable("AppUsersRoles");
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasOne(x => x.User)
                 .WithMany()
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

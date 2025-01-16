using LibruaryAPI.Domain.Common;
using LibruaryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibruaryAPI.Infrastructure.Configurations
{
    /// <summary>
    /// Конфигурация для сущности AppRoles.
    /// </summary>
    public class AppRolesConfiguration : IEntityTypeConfiguration<AppRoles>
    {
        public void Configure(EntityTypeBuilder<AppRoles> builder)
        {
            builder.ToTable("AppRoles");
            builder.HasKey(x => x.RoleId);
            builder.Property(x => x.RoleName)
                .IsRequired()
                .HasDefaultValue(UserRole.User)
                .HasConversion(
                    v => (int)v,
                    v => (UserRole)v
                );


            builder
                .HasMany(x => x.User)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);
        }
    }
}

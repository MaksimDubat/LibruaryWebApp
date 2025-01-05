using LibruaryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibruaryAPI.Domain.Configurations
{
    /// <summary>
    /// Конфигурация для сущности AppUsers.
    /// </summary>
    public class AppUsersConfiguration : IEntityTypeConfiguration<AppUsers>
    {
        public void Configure(EntityTypeBuilder<AppUsers> builder)
        {
            builder.ToTable("AppUsers");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Name)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.UserEmail)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.Password)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(x => x.UserEmail)
                .IsUnique();

            builder
                .HasMany(x => x.Role)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder
                .HasMany(x => x.Carts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

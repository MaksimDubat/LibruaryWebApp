using LibruaryAPI.Infrastructure.RefreshTokenSet.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibruaryAPI.Infrastructure.Configurations
{
    /// <summary>
    /// Конфигурация для refresh token.
    /// </summary>
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshTokenOptions>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenOptions> builder)
        {
            builder.ToTable("RefreshToken");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RefreshToken)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.Expiration)
                .IsRequired();
            builder.Property(x => x.UserId)
                .IsRequired();
            builder.Property(x => x.IsRevoked)
                .HasDefaultValue(false);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

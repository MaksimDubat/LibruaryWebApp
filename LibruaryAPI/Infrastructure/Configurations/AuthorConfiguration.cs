using LibruaryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibruaryAPI.Infrastructure.Configurations
{
    /// <summary>
    /// Конфигурация для сущности Author.
    /// </summary>
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(x => x.AuthorId);
            builder.Property(x => x.FirstName)
                .HasMaxLength(128);
            builder.Property(x => x.LastName)
                .HasMaxLength(128);
            builder.Property(x => x.Country)
                .HasMaxLength(128);
            builder.Property(x => x.BirthDate);

            builder
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

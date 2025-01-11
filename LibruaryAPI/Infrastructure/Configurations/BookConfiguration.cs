using LibruaryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibruaryAPI.Infrastructure.Configurations
{
    /// <summary>
    /// Конфигурация для сущности Book.
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.BookId);
            builder.Property(x => x.ISBN)
                .HasMaxLength(13);
            builder.Property(x => x.Title)
                .HasMaxLength(256);
            builder.Property(x => x.Description)
                .HasMaxLength(512);
            builder.Property(x => x.TakenAt);
            builder.Property(x => x.IsAvaiable)
                .HasDefaultValue(true);
            builder.Property(x => x.Image)
                .HasMaxLength(512);
            builder.Property(x => x.Amount)
                .IsRequired();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

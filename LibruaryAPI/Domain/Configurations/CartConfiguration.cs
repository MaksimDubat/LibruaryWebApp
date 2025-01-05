using LibruaryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibruaryAPI.Domain.Configurations
{
    /// <summary>
    /// Конфигурация для сущности Cart.
    /// </summary>
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(x=> x.CartId);

            builder.HasOne(x=>x.User)
                .WithMany()
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Book)
                .WithMany()
                .HasForeignKey(x=>x.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.TakenAt)
                .IsRequired();

            builder.Property(x => x.StorageDays)
                .IsRequired()
                .HasDefaultValue(14);
        }
    }
}

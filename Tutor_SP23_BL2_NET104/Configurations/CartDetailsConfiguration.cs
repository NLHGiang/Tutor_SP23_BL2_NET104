using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Configurations
{
    public class CartDetailsConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.ToTable("CartDetails");
            builder.HasKey(c => new { c.IdProduct, c.IdUser });

            builder.Property(c => c.Amount).IsRequired();

            builder.Property(c => c.CreatedTime).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Product>(c => c.Product)
            .WithMany(c => c.CartDetails)
            .HasForeignKey(c => c.IdProduct)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>(c => c.User)
            .WithMany(c => c.CartDetails)
            .HasForeignKey(c => c.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
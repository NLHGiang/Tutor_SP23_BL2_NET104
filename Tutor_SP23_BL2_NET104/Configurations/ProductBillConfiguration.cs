using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Configurations
{
    public class ProductBillConfiguration : IEntityTypeConfiguration<ProductBill>
    {
        public void Configure(EntityTypeBuilder<ProductBill> builder)
        {
            builder.ToTable("ProductBill");
            builder.HasKey(c => new { c.IdProduct, c.IdBill });

            builder.Property(c => c.Amount).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.ReducedPrice).IsRequired();

            builder.Property(c => c.CreatedTime).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Product>(c => c.Product)
            .WithMany(c => c.ProductBills)
            .HasForeignKey(c => c.IdProduct)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Bill>(c => c.Bill)
            .WithMany(c => c.ProductBills)
            .HasForeignKey(c => c.IdBill)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
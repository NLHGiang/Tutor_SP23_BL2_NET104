using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(c => c.Id);

            //builder.Property(c => c.IdCategory).IsRequired();
            //builder.Property(c => c.Name).HasMaxLength(50).IsUnicode().IsRequired();
            //builder.Property(c => c.Description).IsUnicode().IsRequired();
            //builder.Property(c => c.Amount).IsRequired();
            //builder.Property(c => c.Price).HasColumnType("float").IsRequired();
            //builder.Property(c => c.ReducedPrice).HasColumnType("float").IsRequired();
            //builder.Property(c => c.Image).IsUnicode(false).IsRequired();

            //builder.Property(c => c.CreatedTime).IsRequired();
            //builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Category>(c => c.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(c => c.IdCategory)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
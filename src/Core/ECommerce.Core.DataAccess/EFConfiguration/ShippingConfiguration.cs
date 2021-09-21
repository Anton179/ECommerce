using ECommerce.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Core.DataAccess.EFConfiguration
{
    public class ShippingConfiguration : IEntityTypeConfiguration<ShippingMethod>
    {
        public void Configure(EntityTypeBuilder<ShippingMethod> builder)
        {
            builder.Property(s => s.Price)
                .IsRequired();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(s => s.Orders)
                .WithOne(o => o.Shipping)
                .HasForeignKey(o => o.ShippingId);

            builder.Property(s => s.RowVersion)
                .IsRowVersion();
        }
    }
}

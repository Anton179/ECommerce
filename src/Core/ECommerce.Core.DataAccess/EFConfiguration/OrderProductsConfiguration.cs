using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Core.DataAccess.EFConfiguration
{
    public class OrderProductsConfiguration : IEntityTypeConfiguration<OrderProducts>
    {
        public void Configure(EntityTypeBuilder<OrderProducts> builder)
        {
            builder.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);

            builder.HasOne(o => o.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(o => o.OrderId);

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.Property(o => o.RowVersion)
                .IsRowVersion();
        }
    }
}

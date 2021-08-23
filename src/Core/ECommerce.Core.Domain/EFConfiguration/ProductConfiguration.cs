using System.Collections.Generic;
using ECommerce.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace ECommerce.Core.DataAccess.EFConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(p => p.Weight)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.OwnerId);

            builder.HasMany(p => p.Characteristics)
                .WithOne(ch => ch.Product)
                .HasForeignKey(ch => ch.ProductId);
        }
    }
}

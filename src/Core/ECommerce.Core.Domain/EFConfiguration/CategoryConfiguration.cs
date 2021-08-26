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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.SubCategories)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValue(DateTime.Today)
                .HasColumnType("Date");

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Characteristics)
                .WithOne(ch => ch.Category)
                .HasForeignKey(ch => ch.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

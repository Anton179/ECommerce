using ECommerce.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Core.DataAccess.EFConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Price)
                .IsRequired();

            builder.Property(o => o.RowVersion)
                .IsRowVersion();

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.Property(o => o.CreatedDate)
            //    .HasColumnType("date");
            
            //builder.Property(o => o.UpdatedDate)
            //    .HasColumnType("date");
        }
    }
}

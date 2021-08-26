using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Core.DataAccess.EFConfiguration
{
    public class CharacteristicValueConfiguration : IEntityTypeConfiguration<CharacteristicValue>
    {
        public void Configure(EntityTypeBuilder<CharacteristicValue> builder)
        {
            builder.HasOne(ch => ch.Characteristic)
                .WithMany(ch => ch.Characteristics)
                .HasForeignKey(ch => ch.CharacteristicId);

            builder.Property(ch => ch.CreatedAt)
                .HasDefaultValue(DateTime.Today)
                .HasColumnType("Date");

            builder.Property(ch => ch.RowVersion)
                .IsRowVersion();
        }
    }
}

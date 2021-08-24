using System;

namespace ECommerce.Core.DataAccess.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } 
        public DateTime CreatedAt { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

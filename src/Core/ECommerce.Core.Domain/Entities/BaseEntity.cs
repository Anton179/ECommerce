using System;

namespace ECommerce.Core.DataAccess.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

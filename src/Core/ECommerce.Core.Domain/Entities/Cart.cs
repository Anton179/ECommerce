using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Auth;

namespace ECommerce.Core.DataAccess.Entities
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

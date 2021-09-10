using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.DataAccess.Entities
{
    public class Shipping : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Estimated { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

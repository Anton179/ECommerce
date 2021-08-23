using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DataAccess.Entities.Characteristics
{
    public class Characteristic : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
        public string Name { get; set; }
    }
}

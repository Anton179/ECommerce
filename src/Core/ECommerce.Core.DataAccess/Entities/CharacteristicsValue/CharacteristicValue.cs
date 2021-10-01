using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DataAccess.Entities.CharacteristicsValue
{
    public class CharacteristicValue : BaseEntity
    {
        public Guid CharacteristicId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Characteristic Characteristic { get; set; }
        public virtual Product Product { get; set; }
    }
}

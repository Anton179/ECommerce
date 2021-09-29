using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;

namespace ECommerce.Core.DataAccess.Entities
{
    public class Characteristic : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<CharacteristicValue> Characteristics { get; set; }
    }
}

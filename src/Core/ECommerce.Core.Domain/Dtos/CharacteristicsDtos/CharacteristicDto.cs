using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos
{
    public class CharacteristicDto
    {
        public string Name { get; set; }
        public string ValueStr { get; set; }
        public double ValueNum { get; set; }
    }
}

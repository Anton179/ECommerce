using System;

namespace ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos
{
    public class CharacteristicValueDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
    }
}

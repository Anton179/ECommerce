using System;

namespace ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos
{
    public class CharacteristicValueForCreateDto
    {
        public Guid CharacteristicId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ValueInt { get; set; }
        public string ValueStr { get; set; }
    }
}

using System;

namespace ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos
{
    public class CharacteristicDto
    {
        public Guid CharacteristicId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}

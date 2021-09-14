﻿using System;

namespace ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos
{
    public class CharacteristicValueDto
    {
        public Guid CharacteristicId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}

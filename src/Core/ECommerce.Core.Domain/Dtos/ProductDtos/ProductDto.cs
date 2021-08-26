using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Dtos.CategoryDtos;
using ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos;
using ECommerce.Core.DataAccess.Dtos.UserDtos;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Enums;

namespace ECommerce.Core.DataAccess.Dtos.ProductDtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; }
        public virtual UserDto User { get; set; }
        public virtual CategoryWithParentDto Category { get; set; }
        public virtual ICollection<CharacteristicValueDto> Characteristics { get; set; }
    }
}

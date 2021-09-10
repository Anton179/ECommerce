using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.DataAccess.Dtos.OrderDtos
{
    public class OrderProductsDto
    {
        public virtual ProductForDisplayDto Product { get; set; }
        public int Quantity { get; set; }
    }
}

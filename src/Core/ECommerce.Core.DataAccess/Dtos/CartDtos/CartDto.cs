using System;
using ECommerce.Core.DataAccess.Dtos.ProductDtos;

namespace ECommerce.Core.DataAccess.Dtos.CartDtos
{
    public class CartDto
    {
        public ProductForDisplayDto Product { get; set; }
        public int Quantity { get; set; }
    }
}

using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;

namespace ECommerce.Core.Application.Infrastructure.Dtos.CartItemDtos
{
    public class CartItemDto
    {
        public ProductForDisplayDto Product { get; set; }
        public int Quantity { get; set; }
    }
}

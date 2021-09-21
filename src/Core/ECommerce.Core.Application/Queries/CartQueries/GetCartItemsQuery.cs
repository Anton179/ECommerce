using MediatR;
using System.Collections.Generic;
using ECommerce.Core.Application.Infrastructure.Dtos.CartItemDtos;

namespace ECommerce.Core.Application.Queries.CartQueries
{
    public class GetCartItemsQuery : IRequest<IEnumerable<CartItemDto>>
    {
    }
}

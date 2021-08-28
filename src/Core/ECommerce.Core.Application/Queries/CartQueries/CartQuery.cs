using System.Collections.Generic;
using ECommerce.Core.DataAccess.Dtos.CartDtos;
using MediatR;

namespace ECommerce.Core.Application.Queries.CartQueries
{
    public class CartQuery : IRequest<IEnumerable<CartDto>>
    {
    }
}

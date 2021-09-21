using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;

namespace ECommerce.Core.Application.Queries.Orders
{
    public class GetOrdersQuery : IRequest<PaginatedResult<OrderDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }
}

using ECommerce.Core.DataAccess.Enums;
using MediatR;

namespace ECommerce.Core.Application.Queries.Orders
{
    public class GetNumberOfOrderProductsByCurrentUserQuery : IRequest<int>
    {
        public OrderStatus? Status { get; set; }
    }
}

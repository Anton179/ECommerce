using MediatR;

namespace ECommerce.Core.Application.Queries.CartQueries
{
    public class GetNumberOfProductsInCartItemsQuery : IRequest<int>
    {
    }
}

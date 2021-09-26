using ECommerce.Core.Application.Queries.Orders;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.QueryHandlers.Orders
{
    public class GetNumberOfOrderProductsByCurrentUserHandler : IRequestHandler<GetNumberOfOrderProductsByCurrentUserQuery, int>
    {
        private readonly IGenericRepository<OrderProducts> _orderProductsRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public GetNumberOfOrderProductsByCurrentUserHandler(IGenericRepository<OrderProducts> orderProductsRepository, ICurrentUserProvider currentUserProvider)
        {
            _orderProductsRepository = orderProductsRepository;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<int> Handle(GetNumberOfOrderProductsByCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserProvider.GetUserId();
            int result;

            if (request != null)
            {
                result = await _orderProductsRepository.Read()
                    .CountAsync(x => x.Product.OwnerId == userId && x.Order.Status == request.Status, cancellationToken);
            }
            else
            {
                result = await _orderProductsRepository.Read()
                    .CountAsync(x => x.Product.OwnerId == userId, cancellationToken);
            }

            return result;
        }
    }
}

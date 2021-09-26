using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using ECommerce.Core.Application.Queries.Orders;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.QueryHandlers.Orders
{
    public class GetNumberOfOrdersByCurrentUserQueryHandler : IRequestHandler<GetNumberOfOrdersByCurrentUserQuery, int>
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public GetNumberOfOrdersByCurrentUserQueryHandler(IGenericRepository<Order> orderRepository, ICurrentUserProvider currentUserProvider)
        {
            _orderRepository = orderRepository;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<int> Handle(GetNumberOfOrdersByCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserProvider.GetUserId();
            int result;

            if (request.Status != null)
            {
                result = await _orderRepository.Read().CountAsync(x => x.UserId == userId && x.Status == request.Status, cancellationToken);
            }
            else
            {
                result = await _orderRepository.Read().CountAsync(x => x.UserId == userId, cancellationToken);
            }

            return result;
        }
    }
}

using MediatR;
using System.Collections.Generic;
using ECommerce.Core.Application.Infrastructure.Dtos.ShippingMethodDtos;

namespace ECommerce.Core.Application.Queries.Shipping
{
    public class GetAllShippingMethodsQuery : IRequest<IEnumerable<ShippingMethodDto>>
    {
    }
}

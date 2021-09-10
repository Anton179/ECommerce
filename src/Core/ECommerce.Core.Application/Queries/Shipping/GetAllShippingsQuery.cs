using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Dtos.ShippingDtos;
using MediatR;

namespace ECommerce.Core.Application.Queries.Shipping
{
    public class GetAllShippingsQuery : IRequest<IEnumerable<ShippingDto>>
    {
    }
}

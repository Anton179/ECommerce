using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Core.Application.Queries.CartQueries
{
    public class NumberOfProductsInCartQuery : IRequest<int>
    {
    }
}

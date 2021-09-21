using AutoMapper;
using ECommerce.Core.Application.Queries.Shipping;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.ShippingMethodDtos;

namespace ECommerce.Core.Application.QueryHandlers.ShippingHandlers
{
    public class GetAllShippingMethodsQueryHandler : IRequestHandler<GetAllShippingMethodsQuery, IEnumerable<ShippingMethodDto>>
    {
        private readonly IGenericRepository<ShippingMethod> _repository;
        private readonly IMapper _mapper;

        public GetAllShippingMethodsQueryHandler(IGenericRepository<ShippingMethod> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShippingMethodDto>> Handle(GetAllShippingMethodsQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var shippings = await _repository.ListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<ShippingMethodDto>>(shippings);

            return result;
        }
    }
}

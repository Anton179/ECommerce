using ECommerce.Core.Application.Queries.Shipping;
using ECommerce.Core.DataAccess.Dtos.ShippingDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;

namespace ECommerce.Core.Application.QueryHandlers.ShippingHandlers
{
    public class GetAllShippingsQueryHandler : IRequestHandler<GetAllShippingsQuery, IEnumerable<ShippingDto>>
    {
        private readonly IGenericRepository<Shipping> _repository;
        private readonly IMapper _mapper;

        public GetAllShippingsQueryHandler(IGenericRepository<Shipping> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShippingDto>> Handle(GetAllShippingsQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var shippings = await _repository.ListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<ShippingDto>>(shippings);

            return result;
        }
    }
}

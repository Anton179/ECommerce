using AutoMapper;
using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Infrastructure.API.Exceptions;

namespace ECommerce.Core.Application.CommandHandlers.ProductHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<CharacteristicValue> _characteristicValueRepository;

        public CreateProductHandler(IGenericRepository<Product> productRepository, IMapper mapper,
            ICurrentUserProvider currentUserProvider, IGenericRepository<CharacteristicValue> characteristicValueRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
            _characteristicValueRepository = characteristicValueRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var characteristicsValueList = new List<CharacteristicValue>();

            foreach (var characteristic in request.CharacteristicsValue)
            {
                switch (characteristic.Type)
                {
                    case "System.Decimal":
                    {
                            characteristicsValueList.Add(_mapper.Map<CharacteristicDecimalType>(characteristic));
                            break;
                        }
                    case "System.DateTime":
                        {
                            characteristicsValueList.Add(_mapper.Map<CharacteristicDateType>(characteristic));
                            break;
                        }
                    case "System.String":
                        {
                            characteristicsValueList.Add(_mapper.Map<CharacteristicStringType>(characteristic));
                            break;
                        }
                    case "System.Int32":
                        {
                            characteristicsValueList.Add(_mapper.Map<CharacteristicIntType>(characteristic));
                            break;
                        }
                    default:
                    {
                        throw new ValueOutOfRangeException("Wrong characteristic type!");
                    }
                }
            }

            product.OwnerId = _currentUserProvider.GetUserId();
            product.Characteristics = characteristicsValueList;

            await _productRepository.AddAsync(product, cancellationToken);
            await _characteristicValueRepository.AddRangeAsync(characteristicsValueList, cancellationToken);

            await _productRepository.SaveChangesAsync();
            await _characteristicValueRepository.SaveChangesAsync();

            return product.Id;
        }
    }
}

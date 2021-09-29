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
using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;
using ECommerce.Core.Application.Infrastructure.Exceptions;
using ECommerce.Core.Application.Infrastructure.Interfaces;

namespace ECommerce.Core.Application.CommandHandlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<CharacteristicValue> _characteristicValueRepository;

        public CreateProductCommandHandler(IGenericRepository<Product> productRepository, IMapper mapper,
            ICurrentUserProvider currentUserProvider, IGenericRepository<CharacteristicValue> characteristicValueRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
            _characteristicValueRepository = characteristicValueRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var product = _mapper.Map<Product>(request);
            var characteristicsValueList = MapCharacteristics(request.CharacteristicsValue);

            product.OwnerId = _currentUserProvider.GetUserId();
            product.Characteristics = characteristicsValueList;

            await _productRepository.AddAsync(product);
            await _characteristicValueRepository.AddRangeAsync(characteristicsValueList);

            await _productRepository.SaveChangesAsync();

            return product.Id;
        }

        private List<CharacteristicValue> MapCharacteristics(ICollection<CharacteristicValueDto> characteristicDtos)
        {
            var characteristicsValueList = new List<CharacteristicValue>();

            foreach (var characteristic in characteristicDtos)
            {
                switch (characteristic.Type)
                {
                    case "Decimal":
                        {
                            characteristicsValueList.Add(_mapper.Map<CharacteristicDecimalType>(characteristic));
                            break;
                        }
                    case "DateTime":
                        {
                            characteristicsValueList.Add(_mapper.Map<CharacteristicDateType>(characteristic));
                            break;
                        }
                    case "String":
                        {
                            characteristicsValueList.Add(_mapper.Map<CharacteristicStringType>(characteristic));
                            break;
                        }
                    case "Int32":
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

            return characteristicsValueList;
        }
    }
}

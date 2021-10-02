using AutoMapper;
using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;
using ECommerce.Core.Application.Infrastructure.Exceptions;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.CommandHandlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IGenericRepository<CharacteristicValue> _characteristicValueRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IGenericRepository<Product> productRepository,
                                    ICurrentUserProvider currentUserProvider, IMapper mapper,
                                    IGenericRepository<CharacteristicValue> characteristicValueRepository)
        {
            _productRepository = productRepository;
            _currentUserProvider = currentUserProvider;
            _mapper = mapper;
            _characteristicValueRepository = characteristicValueRepository;
        }
        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var product = await _productRepository.GetByIdAsync((Guid)request.Id);
            var userId = _currentUserProvider.GetUserId();

            if (product == null)
            {
                throw new NotFoundException("Product not found!");
            }

            if (product.OwnerId != userId)
            {
                throw new NoAccessException();
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Weight = request.Weight;
            product.InStock = (bool)request.InStock;
            product.CategoryId = (Guid)request.CategoryId;
            product.ImagePath = request.ImagePath;


            var characteristics = await _characteristicValueRepository.Read().Where(ch => request.Characteristics.Select(x => x.Id).Contains(ch.Id)).ToListAsync();
            characteristics = UpdateCharacteristics(request.Characteristics, characteristics);


            _productRepository.Update(product);
            _characteristicValueRepository.UpdateRange(characteristics);
            await _productRepository.SaveChangesAsync();

            return product.Id;
        }

        private List<CharacteristicValue> UpdateCharacteristics(ICollection<CharacteristicValueDto> characteristicDtos, List<CharacteristicValue> characteristics)
        {
            var characteristicsValueList = new List<CharacteristicValue>();

            foreach (var characteristic in characteristicDtos)
            {
                var characteristicValue = characteristics.Where(x => x.Id == characteristic.Id).FirstOrDefault();
                switch (characteristic.Type)
                {
                    case "Decimal":
                        {
                            ((CharacteristicDecimalType)characteristicValue).ValueDec = _mapper.Map<CharacteristicDecimalType>(characteristic).ValueDec;
                            break;
                        }
                    case "DateTime":
                        {
                            ((CharacteristicDateType)characteristicValue).ValueDate = _mapper.Map<CharacteristicDateType>(characteristic).ValueDate;
                            break;
                        }
                    case "String":
                        {
                            ((CharacteristicStringType)characteristicValue).ValueStr = _mapper.Map<CharacteristicStringType>(characteristic).ValueStr;
                            break;
                        }
                    case "Int32":
                        {
                            ((CharacteristicIntType)characteristicValue).ValueInt = _mapper.Map<CharacteristicIntType>(characteristic).ValueInt;
                            break;
                        }
                    default:
                        {
                            throw new ValueOutOfRangeException("Wrong characteristic type!");
                        }
                }

                characteristicsValueList.Add(characteristicValue);
            }

            return characteristicsValueList;
        }
    }
}

using AutoMapper;
using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;
using ECommerce.Core.Application.Queries.Characteristics;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.QueryHandlers.Characteristics
{
    class GetCharacteristicsByCategoryQueryIdHandler : IRequestHandler<GetCharacteristicsByCategoryIdQuery, List<CharacteristicDto>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCharacteristicsByCategoryQueryIdHandler(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CharacteristicDto>> Handle(GetCharacteristicsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            var characteristics = GetCharacteristicsFromParentsCategory(category);
            var result = _mapper.Map<List<CharacteristicDto>>(characteristics);

            return result;

        }

        private List<Characteristic> GetCharacteristicsFromParentsCategory(Category category)
        {
            List<Characteristic> characteristicList = new List<Characteristic>();

            characteristicList.AddRange(category.Characteristics);
            while (category.ParentId != null)
            {
                category = category.Parent;
                characteristicList.AddRange(category.Characteristics);
            }

            return characteristicList;
        }
    }
}

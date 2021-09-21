using AutoMapper;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos;
using ECommerce.Core.Application.Queries.Categories;

namespace ECommerce.Core.Application.QueryHandlers.Categories
{
    public class GetMainCategoriesQueryHandler : IRequestHandler<GetMainCategoriesQuery, IEnumerable<CategoryWithImageDto>>
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetMainCategoriesQueryHandler(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryWithImageDto>> Handle(GetMainCategoriesQuery request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var mainCategories = await _repository.Read().Where(c => c.Parent == null && c.Image != null).ToListAsync(cancellationToken);

            var result = _mapper.Map<List<CategoryWithImageDto>>(mainCategories);

            return result;
        }
    }
}

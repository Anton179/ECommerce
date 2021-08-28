using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.Application.Queries.Categories;
using ECommerce.Core.DataAccess.Dtos.CategoryDtos;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            CancellationToken cancellationToken)
        {
            var mainCategories = await _repository.Read().Where(c => c.Parent == null && !String.IsNullOrEmpty(c.Image)).ToListAsync(cancellationToken);

            var result = _mapper.Map<List<CategoryWithImageDto>>(mainCategories);

            return result;
        }
    }
}

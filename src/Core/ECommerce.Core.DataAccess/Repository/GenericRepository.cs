using ECommerce.Core.DataAccess;
using ECommerce.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DataAccess.Extensions;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;

namespace ECommerce.Core.DataAccess.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ECommerceDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(ECommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        public async Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().ToListAsync(cancellationToken);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public IQueryable<TEntity> Read() => _context.Set<TEntity>();

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().UpdateRange(entities);
        public async Task<PaginatedResult<TDto>> GetPagedData<TDto>(PagedRequest request) where TDto : class => 
            await _context.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(request, _mapper);
        }
}

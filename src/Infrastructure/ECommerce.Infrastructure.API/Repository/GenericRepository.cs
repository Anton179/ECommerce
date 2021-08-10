using ECommerce.Core.Application.Interfaces;
using ECommerce.Core.DataAccess;
using ECommerce.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.API.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ECommerceDbContext _context;

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

        public TEntity GetById(Guid id) => _context.Set<TEntity>().SingleOrDefault(e => e.Id == id);

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id, cancellationToken);

        public List<TEntity> List() => _context.Set<TEntity>().ToList();

        public async Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default) =>
            await _context.Set<TEntity>().ToListAsync(cancellationToken);

        public IQueryable<TEntity> Read() => _context.Set<TEntity>().OrderBy(e => e.Id);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().UpdateRange(entities);
    }
}

using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Common;
using Inkwave.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<List<T>> AddRangeAsync(IEnumerable<T> entitys)
        {
            await _dbContext.Set<T>().AddRangeAsync(entitys);
            return entitys.ToList();
        }
        public Task UpdateAsync(T entity)
        {
            T exist = _dbContext.Set<T>().Find(entity.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetByIdsAsync(IEnumerable<Guid> guids)
        {
            return await _dbContext.Set<T>().Where(x => guids.Contains(x.Id)).ToListAsync();
        }


    }
}

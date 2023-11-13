using Inkwave.Domain.Common.Interfaces;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(IEnumerable<T> entitys);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetByIdsAsync(IEnumerable<Guid> guids);
    }
}

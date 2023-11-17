namespace Inkwave.Application.Interfaces.Repositories;

public interface IItemRepository : IGenericRepository<Item>
{
    Task<bool> ItemIsActive(Guid id);
}

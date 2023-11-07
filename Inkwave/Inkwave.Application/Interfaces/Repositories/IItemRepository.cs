namespace Inkwave.Application.Interfaces.Repositories;

public interface IItemRepository
{
    Task<bool> ItemIsActive(Guid id);
}

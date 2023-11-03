using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Item;

namespace Inkwave.Persistence.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly IGenericRepository<Item> _repository;

    public ItemRepository(IGenericRepository<Item> repository)
    {
        _repository = repository;
    }
}

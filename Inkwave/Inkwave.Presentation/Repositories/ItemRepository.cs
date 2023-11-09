using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Item;
using Inkwave.Persistence.Contexts;

namespace Inkwave.Persistence.Repositories;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> ItemIsActive(Guid id)
    {
        throw new NotImplementedException();
    }
}

using Inkwave.Domain;
using Inkwave.Domain.Item;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> AddItemCart(Guid userId, Guid itemId, double quantity);
        Task RemoveItemCart(Guid userId, Guid itemId);
        Task<List<Item>> GetItemsCartByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    }
}

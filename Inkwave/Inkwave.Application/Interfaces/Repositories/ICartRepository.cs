using Inkwave.Domain;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> AddItemCart(Guid userId, Guid itemId, double quantity);
        Task<bool> RemoveItemCart(Guid userId, Guid itemId);
        Task<List<Cart>> GetCartByUserId(Guid userId);
    }
}

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> AddItemCart(Guid userId, Guid itemId, double quantity);
        Task<Cart> UpdateQuantityAsync(Guid userId, Guid itemId, double quantity);
        Task RemoveItemCart(Guid userId, Guid itemId);
        Task<List<Cart>> GetCartByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task ClearCart(Guid customerId);
    }
}

using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain;
using Inkwave.Domain.Item;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        readonly IGenericRepository<Cart> cartRepository;
        readonly IGenericRepository<Item> itemRepository;

        public CartRepository(IGenericRepository<Cart> cartRepository, IGenericRepository<Item> itemRepository)
        {
            this.cartRepository = cartRepository;
            this.itemRepository = itemRepository;
        }

        public Task<Cart> AddItemCart(Guid userId, Guid itemId, double quantity)
        {
            var cart = Cart.Create(userId, itemId, quantity);
            cartRepository.AddAsync(cart);
            return Task.FromResult(cart);
        }


        public async Task<List<Item>> GetItemsCartByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var UserItems = await cartRepository.Entities.Where(x => x.UserId == userId).Select(x => x.ItemId).ToListAsync();
            return await itemRepository.Entities.Where(x => UserItems.Contains(x.Id)).ToListAsync(cancellationToken);
        }

        public Task RemoveItemCart(Guid userId, Guid itemId)
        {
            var cart = cartRepository.Entities.FirstOrDefault(x => x.UserId == userId && x.ItemId == itemId);
            if (cart != null)
                cartRepository.DeleteAsync(cart);
            return Task.FromResult(cart);
        }
    }
}

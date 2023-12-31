﻿using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        readonly IGenericRepository<Cart> cartRepository;

        public CartRepository(IGenericRepository<Cart> cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public Task<Cart> AddItemCart(Guid userId, Guid itemId, double quantity)
        {
            var cart = Cart.Create(userId, itemId, quantity);
            cartRepository.AddAsync(cart);
            return Task.FromResult(cart);
        }
        public async Task<Cart> UpdateQuantityAsync(Guid userId, Guid itemId, double quantity)
        {
            Cart? cart = await cartRepository.Entities.FirstOrDefaultAsync(x => x.UserId == userId && x.ItemId == itemId);
            if (cart != null)
            {
                cart.Quantity = quantity;
                await cartRepository.UpdateAsync(cart);
            }
            return cart;
        }

        public async Task ClearCart(Guid userId)
        {
            var carts = await cartRepository.Entities.Where(x => x.UserId == userId).ToListAsync();
            carts.ForEach(async x => await cartRepository.DeleteAsync(x));
        }

        public async Task<List<Cart>> GetCartByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await cartRepository.Entities.Where(x => x.UserId == userId).ToListAsync();
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

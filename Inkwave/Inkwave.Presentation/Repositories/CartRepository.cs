using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain;

namespace Inkwave.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        readonly IGenericRepository<Cart> genericRepository;
        public CartRepository(IGenericRepository<Cart> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public Task<Cart> AddItemCart(Guid userId, Guid itemId, double quantity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetCartByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemCart(Guid userId, Guid itemId)
        {
            throw new NotImplementedException();
        }
    }
}

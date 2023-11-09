using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain;

namespace Inkwave.Persistence.Repositories
{
    public class FavouriteRepository : IFavouriteRepository
    {
        readonly IGenericRepository<Favourite> genericRepository;
        public FavouriteRepository(IGenericRepository<Favourite> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<Favourite> AddItemFavourite(Guid userId, Guid itemId)
        {
            var model = new Favourite { UserId = userId, ItemId = itemId };
            await genericRepository.AddAsync(model);
            return model;
        }

        public Task<List<Favourite>> GetFavouriteByUserId(Guid usetId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemFavourite(Guid usetId, Guid itemId)
        {
            throw new NotImplementedException();
        }
    }
}

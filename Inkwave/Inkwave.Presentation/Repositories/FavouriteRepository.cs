﻿using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public Task<List<Favourite>> GetFavouriteByUserIdAsync(Guid usetId, CancellationToken cancellationToken)
        {
            return genericRepository.Entities.Where(x => x.UserId == usetId).ToListAsync(cancellationToken);
        }

        public Task RemoveItemFavourite(Guid usetId, Guid itemId)
        {
            var model = genericRepository.Entities.FirstOrDefault(x => x.UserId == usetId && x.ItemId == itemId);
            if (model != null)
                genericRepository.DeleteAsync(model);
            return Task.FromResult(model);

        }
    }
}

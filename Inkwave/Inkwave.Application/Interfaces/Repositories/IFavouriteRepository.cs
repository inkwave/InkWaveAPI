using Inkwave.Domain;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IFavouriteRepository
    {
        Task<Favourite> AddItemFavourite(Guid usetId, Guid itemId);
        Task RemoveItemFavourite(Guid usetId, Guid itemId);
        Task<List<Favourite>> GetFavouriteByUserIdAsync(Guid usetId, CancellationToken cancellationToken);
    }
}

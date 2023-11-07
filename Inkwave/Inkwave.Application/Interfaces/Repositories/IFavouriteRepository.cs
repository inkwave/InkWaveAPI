using Inkwave.Domain;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IFavouriteRepository
    {
        Task<Favourite> AddItemFavourite(Guid usetId, Guid itemId);
        Task<bool> RemoveItemFavourite(Guid usetId, Guid itemId);
        Task<List<Favourite>> GetFavouriteByUserId(Guid usetId);
    }
}

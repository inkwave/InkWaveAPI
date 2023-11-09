using Inkwave.Application.Common.Mappings;
using Inkwave.Domain;

namespace Inkwave.Application.Features.Favourites.Queries.GetMyFavourite
{
    public class GetMyFavouriteDto : IMapFrom<Favourite>
    {
        public Guid Id { get; init; }
        public Guid UserId { get; set; }
    }
}

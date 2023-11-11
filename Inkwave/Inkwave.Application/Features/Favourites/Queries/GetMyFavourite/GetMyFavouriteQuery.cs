using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Favourites.Queries.GetMyFavourite
{
    public record GetMyFavouriteQuery : IRequest<Result<List<GetMyFavouriteDto>>>
    {
        public Guid UserId { get; set; }

        public GetMyFavouriteQuery(Guid UserId)
        {
            this.UserId = UserId;
        }
    }
}


using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Favourites.Queries.GetMyFavourite
{
    public record GetMyFavouriteQuery : IRequest<Result<GetMyFavouriteDto>>
    {
        public GetMyFavouriteQuery(Guid Id)
        {
            this.Id = Id;
        }
        public Guid Id { get; set; }
    }
}


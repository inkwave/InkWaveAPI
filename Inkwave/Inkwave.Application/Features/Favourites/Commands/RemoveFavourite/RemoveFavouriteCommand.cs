using Inkwave.Shared;
using MediatR;


namespace inkwave.application.features.favourites.commands.addfavourite
{
    public record RemoveFavouriteCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
    }
}

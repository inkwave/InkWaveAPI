namespace Inkwave.Application.Features.Favourites.Commands.AddFavourite
{
    public record AddFavouriteCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
    }
}

namespace Inkwave.Application.Features.Favourites.Commands.RemoveFavourite;

public record RemoveFavouriteCommand : IRequest<Result<Guid>>
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
}

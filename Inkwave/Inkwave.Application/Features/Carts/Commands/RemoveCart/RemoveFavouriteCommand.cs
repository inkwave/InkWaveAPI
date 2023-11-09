using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Carts.Commands.RemoveCart;

public record RemoveCartCommand : IRequest<Result<Guid>>
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
}

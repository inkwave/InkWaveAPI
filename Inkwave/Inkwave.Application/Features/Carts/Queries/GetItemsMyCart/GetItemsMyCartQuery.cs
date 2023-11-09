using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Carts.Queries.GetItemsMyCart;

public record GetItemsMyCartQuery : IRequest<Result<List<GetItemsMyCartDto>>>
{
    public Guid UserId { get; set; }
}

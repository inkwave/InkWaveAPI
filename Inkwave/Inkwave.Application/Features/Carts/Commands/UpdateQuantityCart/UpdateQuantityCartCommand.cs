using Inkwave.Domain;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Carts.Commands.UpdateQuantityCart
{
    public record UpdateQuantityCartCommand : IRequest<Result<Cart>>
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public double Quantity { get; set; }
    }
}

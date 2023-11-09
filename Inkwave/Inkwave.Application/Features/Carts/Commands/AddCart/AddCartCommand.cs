using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Carts.Commands.AddCart
{
    public record AddCartCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public double Quantity { get; set; }
    }
}

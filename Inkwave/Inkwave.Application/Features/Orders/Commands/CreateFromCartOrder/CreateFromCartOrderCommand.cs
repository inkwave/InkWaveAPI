using Inkwave.Domain;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Orders.Commands.CreateFromCartOrder
{
    public record CreateFromCartOrderCommand : IRequest<Result<Order>>
    {
        public Guid UserId { get; set; }
        public Guid BillingAddressId { get; set; }
        public Guid ShippingAddressId { get; set; }
    }
}

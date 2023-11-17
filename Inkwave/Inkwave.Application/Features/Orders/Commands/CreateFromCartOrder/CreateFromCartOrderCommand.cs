namespace Inkwave.Application.Features.Orders.Commands.CreateFromCartOrder
{
    public record CreateFromCartOrderCommand : IRequest<Result<Order>>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public bool IsCashOnDelivery { get; set; }
    }
}

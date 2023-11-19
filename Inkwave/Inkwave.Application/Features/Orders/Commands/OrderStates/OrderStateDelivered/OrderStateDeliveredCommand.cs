namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateDelivered;

public record OrderStateDeliveredCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }

}

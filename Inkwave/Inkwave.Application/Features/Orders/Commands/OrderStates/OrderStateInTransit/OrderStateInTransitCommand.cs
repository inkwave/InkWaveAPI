namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateInTransit;

public record OrderStateInTransitCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }

}

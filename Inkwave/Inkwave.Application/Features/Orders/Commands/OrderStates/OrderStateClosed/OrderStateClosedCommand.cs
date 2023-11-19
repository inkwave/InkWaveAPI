namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateClosed;

public record OrderStateClosedCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }

}

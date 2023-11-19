namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStatePending;

public record OrderStatePendingCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }

}

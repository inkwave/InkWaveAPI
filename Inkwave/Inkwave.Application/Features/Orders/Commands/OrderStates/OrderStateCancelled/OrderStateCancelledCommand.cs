namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateCancelled;

public record OrderStateCancelledCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }
    public string Description { get; set; }

}

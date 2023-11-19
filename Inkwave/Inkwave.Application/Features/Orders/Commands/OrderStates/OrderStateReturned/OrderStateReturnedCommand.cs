namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateReturned;

public record OrderStateReturnedCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }
    public string Description { get; set; }

}

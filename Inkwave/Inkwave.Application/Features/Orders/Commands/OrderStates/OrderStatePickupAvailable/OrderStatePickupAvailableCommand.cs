namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStatePickupAvailable;

public record OrderStatePickupAvailableCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }

}
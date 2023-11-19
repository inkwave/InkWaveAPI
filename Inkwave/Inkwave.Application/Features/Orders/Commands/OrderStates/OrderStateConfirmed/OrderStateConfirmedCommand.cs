namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateConfirmed;

public record OrderStateConfirmedCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }

}
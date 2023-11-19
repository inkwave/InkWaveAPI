namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateProcessing;

public record OrderStateProcessingCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }

}

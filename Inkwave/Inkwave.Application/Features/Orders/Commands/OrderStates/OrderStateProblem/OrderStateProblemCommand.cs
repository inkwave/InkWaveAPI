namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateProblem;

public record OrderStateProblemCommand : IRequest<Result<Order>>
{
    public Guid OrderId { get; set; }
    public string Description { get; set; }

}

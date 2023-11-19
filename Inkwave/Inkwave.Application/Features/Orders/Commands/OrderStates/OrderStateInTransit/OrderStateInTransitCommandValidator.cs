using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateInTransit;
public class OrderStateInTransitCommandValidator : AbstractValidator<OrderStateInTransitCommand>
{
    private readonly IOrderRepository orderRepository;

    public OrderStateInTransitCommandValidator(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;

        RuleFor(x => x.OrderId)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsFound).WithMessage("{PropertyName} should be not empty. NEVER!");
    }
    public async Task<bool> IsFound(Guid orderId, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId);
        return order != null;
    }
}
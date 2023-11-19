using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateClosed;
public class OrderStateClosedCommandValidator : AbstractValidator<OrderStateClosedCommand>
{
    private readonly IOrderRepository orderRepository;

    public OrderStateClosedCommandValidator(IOrderRepository orderRepository)
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
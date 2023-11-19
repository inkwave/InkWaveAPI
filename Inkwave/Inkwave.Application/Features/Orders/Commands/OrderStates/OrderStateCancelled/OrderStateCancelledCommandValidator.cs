using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateCancelled;


public class OrderStateCancelledCommandValidator : AbstractValidator<OrderStateCancelledCommand>
{
    private readonly IOrderRepository orderRepository;

    public OrderStateCancelledCommandValidator(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;

        RuleFor(x => x.OrderId)
            .NotEmpty()
            .NotNull()
            .MustAsync(IsFound).WithMessage("{PropertyName} should be not empty. NEVER!");

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull();
    }
    public async Task<bool> IsFound(Guid orderId, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId);
        return order != null;
    }
}
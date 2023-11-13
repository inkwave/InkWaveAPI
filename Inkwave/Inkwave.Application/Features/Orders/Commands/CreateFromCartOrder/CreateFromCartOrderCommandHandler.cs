using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Orders.Commands.CreateFromCartOrder;

internal class CreateFromCartOrderCommandHandler : IRequestHandler<CreateFromCartOrderCommand, Result<Order>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IOrderRepository _OrderRepository;
    private readonly ICartRepository _cartRepository;

    public CreateFromCartOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, ICartRepository cartRepository)
    {
        this.unitOfWork = unitOfWork;
        this._OrderRepository = orderRepository;
        _cartRepository = cartRepository;
    }

    public async Task<Result<Order>> Handle(CreateFromCartOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _OrderRepository.CreateOrderFromCartAsync(command.UserId, command.BillingAddressId, command.ShippingAddressId, cancellationToken);
        await unitOfWork.Save(cancellationToken);
        if (order != null)
        {
            await _cartRepository.ClearCart(command.UserId);
            await unitOfWork.Save(cancellationToken);
            return await Result<Order>.SuccessAsync(order, "Add order.");
        }
        else
            return await Result<Order>.FailureAsync("error in the order");
    }
}
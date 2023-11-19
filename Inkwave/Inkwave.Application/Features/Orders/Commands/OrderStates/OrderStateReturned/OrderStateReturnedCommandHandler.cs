using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateReturned;

internal class OrderStateReturnedCommandHandler : IRequestHandler<OrderStateReturnedCommand, Result<Order>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _OrderRepository;
    public OrderStateReturnedCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _OrderRepository = orderRepository;
    }
    public async Task<Result<Order>> Handle(OrderStateReturnedCommand request, CancellationToken cancellationToken)
    {
        var order = await _OrderRepository.GetOrderByIdAsync(request.OrderId);
        order.OrderStateContext.Returned(request.Description);
        var result = await _unitOfWork.Save(cancellationToken);
        if (result > 0)
            return Result<Order>.Success();
        return Result<Order>.Failure();
    }
}

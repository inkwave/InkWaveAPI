using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Result<List<GetOrdersByUserIdDto>>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersByUserIdQueryHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<Result<List<GetOrdersByUserIdDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userOrders = await _orderRepository.GetOrdersByUserIdAsync(request.UserId, cancellationToken);
        return Result<List<GetOrdersByUserIdDto>>.Success(_mapper.Map<List<GetOrdersByUserIdDto>>(userOrders));
    }
}

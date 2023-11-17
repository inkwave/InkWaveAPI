namespace Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByUserIdQuery : IRequest<Result<List<GetOrdersByUserIdDto>>>
{
    public Guid UserId { get; set; }

}



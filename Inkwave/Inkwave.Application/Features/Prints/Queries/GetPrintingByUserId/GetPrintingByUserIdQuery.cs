namespace Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetPrintingByUserIdQuery : IRequest<Result<List<GetPrintingByUserIdDto>>>
{
    public Guid UserId { get; set; }

}



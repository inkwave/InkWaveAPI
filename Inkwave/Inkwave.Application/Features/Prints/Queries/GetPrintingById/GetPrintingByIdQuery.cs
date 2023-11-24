namespace Inkwave.Application.Features.Orders.Queries.GetOrdersById;

public class GetPrintingByIdQuery : IRequest<Result<List<GetPrintingByIdDto>>>
{
    public Guid Id { get; set; }

}



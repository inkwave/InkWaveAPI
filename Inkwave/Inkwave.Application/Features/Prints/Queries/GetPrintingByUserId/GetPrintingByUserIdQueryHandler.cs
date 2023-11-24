using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetPrintingByUserIdQueryHandler : IRequestHandler<GetPrintingByUserIdQuery, Result<List<GetPrintingByUserIdDto>>>
{
    private readonly IPrintingRepository _printingRepository;
    private readonly IMapper _mapper;

    public GetPrintingByUserIdQueryHandler(IPrintingRepository printingRepository, IMapper mapper)
    {
        _printingRepository = printingRepository;
        _mapper = mapper;
    }
    public async Task<Result<List<GetPrintingByUserIdDto>>> Handle(GetPrintingByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userOrders = await _printingRepository.GetPrintingByUserIdAsync(request.UserId);
        return Result<List<GetPrintingByUserIdDto>>.Success(_mapper.Map<List<GetPrintingByUserIdDto>>(userOrders));
    }
}

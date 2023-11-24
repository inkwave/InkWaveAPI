using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Orders.Queries.GetOrdersById;

public class GetPrintingByIdQueryHandler : IRequestHandler<GetPrintingByIdQuery, Result<List<GetPrintingByIdDto>>>
{
    private readonly IPrintingRepository _printingRepository;
    private readonly IMapper _mapper;

    public GetPrintingByIdQueryHandler(IPrintingRepository printingRepository, IMapper mapper)
    {
        _printingRepository = printingRepository;
        _mapper = mapper;
    }
    public async Task<Result<List<GetPrintingByIdDto>>> Handle(GetPrintingByIdQuery request, CancellationToken cancellationToken)
    {
        var Orders = await _printingRepository.GetPrintingByIdAsync(request.Id);
        return Result<List<GetPrintingByIdDto>>.Success(_mapper.Map<List<GetPrintingByIdDto>>(Orders));
    }
}

using AutoMapper;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Carts.Queries.GetItemsMyCart;

internal class GetItemsMyCartQueryHandler : IRequestHandler<GetItemsMyCartQuery, Result<List<GetItemsMyCartDto>>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public GetItemsMyCartQueryHandler(IMapper mapper, ICartRepository cartRepository)
    {
        _mapper = mapper;
        _cartRepository = cartRepository;
    }

    public async Task<Result<List<GetItemsMyCartDto>>> Handle(GetItemsMyCartQuery query, CancellationToken cancellationToken)
    {
        var userItems = await _cartRepository.GetItemsCartByUserIdAsync(query.UserId, cancellationToken);
        var result = _mapper.Map<List<GetItemsMyCartDto>>(userItems);
        return await Result<List<GetItemsMyCartDto>>.SuccessAsync(result);
    }
}

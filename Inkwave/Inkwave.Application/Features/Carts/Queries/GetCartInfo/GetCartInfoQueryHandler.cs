using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Carts.Queries.GetCartInfo;

internal class GetCartInfoQueryHandler : IRequestHandler<GetCartInfoDtoQuery, Result<GetCartInfoDto>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetCartInfoQueryHandler(IMapper mapper, ICartRepository cartRepository, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _cartRepository = cartRepository;
        _itemRepository = itemRepository;
    }

    public async Task<Result<GetCartInfoDto>> Handle(GetCartInfoDtoQuery query, CancellationToken cancellationToken)
    {
        GetCartInfoDto result = new GetCartInfoDto();
        var userCarts = await _cartRepository.GetCartByUserIdAsync(query.UserId, cancellationToken);
        foreach (var cart in userCarts)
        {
            var row = _mapper.Map<GetItemsMyCartDto>(await _itemRepository.GetByIdAsync(cart.ItemId));
            if (row != null)
            {
                row.Quantity = cart.Quantity;
                result.Items.Add(row);
            }
        }
        return await Result<GetCartInfoDto>.SuccessAsync(result);
    }
}

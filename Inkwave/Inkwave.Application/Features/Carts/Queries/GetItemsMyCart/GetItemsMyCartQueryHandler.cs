using AutoMapper;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Carts.Queries.GetItemsMyCart;

internal class GetItemsMyCartQueryHandler : IRequestHandler<GetItemsMyCartQuery, Result<List<GetItemsMyCartDto>>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetItemsMyCartQueryHandler(IMapper mapper, ICartRepository cartRepository, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _cartRepository = cartRepository;
        _itemRepository = itemRepository;
    }

    public async Task<Result<List<GetItemsMyCartDto>>> Handle(GetItemsMyCartQuery query, CancellationToken cancellationToken)
    {
        List<GetItemsMyCartDto> result = new List<GetItemsMyCartDto>();
        var userCarts = await _cartRepository.GetCartByUserIdAsync(query.UserId, cancellationToken);
        foreach (var cart in userCarts)
        {
            var row = _mapper.Map<GetItemsMyCartDto>(await _itemRepository.GetByIdAsync(cart.ItemId));
            if (row != null)
            {
                row.Quantity = cart.Quantity;
                result.Add(row);
            }
        }

        return await Result<List<GetItemsMyCartDto>>.SuccessAsync(result);
    }
}

using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Favourites.Queries.GetMyFavourite
{
    internal class GetMyFavouriteQueryHandler : IRequestHandler<GetMyFavouriteQuery, Result<List<GetMyFavouriteDto>>>
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;


        public GetMyFavouriteQueryHandler(IFavouriteRepository favouriteRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _favouriteRepository = favouriteRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetMyFavouriteDto>>> Handle(GetMyFavouriteQuery query, CancellationToken cancellationToken)
        {
            List<GetMyFavouriteDto> result = new List<GetMyFavouriteDto>();
            var userCarts = await _favouriteRepository.GetFavouriteByUserIdAsync(query.UserId, cancellationToken);
            foreach (var cart in userCarts)
            {
                var row = _mapper.Map<GetMyFavouriteDto>(await _itemRepository.GetByIdAsync(cart.ItemId));
                if (row != null)
                    result.Add(row);
            }

            return await Result<List<GetMyFavouriteDto>>.SuccessAsync(result);

        }
    }
}


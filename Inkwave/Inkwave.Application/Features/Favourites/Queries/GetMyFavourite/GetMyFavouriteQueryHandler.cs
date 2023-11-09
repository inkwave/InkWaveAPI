using AutoMapper;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain;
using Inkwave.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Favourites.Queries.GetMyFavourite
{
    internal class GetMyFavouriteQueryHandler : IRequestHandler<GetMyFavouriteQuery, Result<GetMyFavouriteDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetMyFavouriteQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetMyFavouriteDto>> Handle(GetMyFavouriteQuery query, CancellationToken cancellationToken)
        {

            var favourite = await _unitOfWork.Repository<Favourite>().Entities
                .Include(x => x.ItemId)
                .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            if (favourite == null) return await Result<GetMyFavouriteDto>.FailureAsync("favourite not fund");
            var result = _mapper.Map<GetMyFavouriteDto>(favourite);

            favourite.ItemId?.ToList().ForEach(x =>
            {

                result.ItemId.Add(_mapper.Map<GetMyFavouriteItemDto>(x.ItemId));
            });
            return await Result<GetMyFavouriteDto>.SuccessAsync(result);
        }
    }
}


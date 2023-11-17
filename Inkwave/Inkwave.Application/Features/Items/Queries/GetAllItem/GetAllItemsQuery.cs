using AutoMapper.QueryableExtensions;
using Inkwave.Application.Features.Items.Queries.GetAllItem;
using Inkwave.Application.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Items.Queries.GetItemsWithPagination;

public record GetAllItemsQuery : IRequest<Result<List<GetAllItemsDto>>>;

internal class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, Result<List<GetAllItemsDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllItemsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllItemsDto>>> Handle(GetAllItemsQuery query, CancellationToken cancellationToken)
    {
        var Items = await _unitOfWork.Repository<Item>().Entities.Include(x => x.SubDescription)
               .ProjectTo<GetAllItemsDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

        var ItemCategorys = await _unitOfWork.Repository<ItemCategory>().Entities
            .Include(x => x.Category).ToListAsync();

        ItemCategorys.ForEach(x =>
        {
            var category = _mapper.Map<GetAllItemCategoryDto>(x.Category);
            Items.FirstOrDefault(i => i.Id == x.ItemId)?.Categorys.Add(category);
        });
        return await Result<List<GetAllItemsDto>>.SuccessAsync(Items);
    }
}

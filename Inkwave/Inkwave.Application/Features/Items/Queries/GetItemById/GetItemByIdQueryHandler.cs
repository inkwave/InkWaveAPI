using AutoMapper;
using Inkwave.Application.Features.Items.Queries.GetItemById;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Item;
using Inkwave.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Items.Queries.GetItemsWithPagination;

internal class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, Result<GetItemByIdDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetItemByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetItemByIdDto>> Handle(GetItemByIdQuery query, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.Repository<Item>().Entities
            .Include(x => x.SubDescription)
            .Include("ItemCategorys.Category")
            .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
        if (item == null) return await Result<GetItemByIdDto>.FailureAsync("item not fund");
        var result = _mapper.Map<GetItemByIdDto>(item);

        item.ItemCategorys?.ToList().ForEach(x =>
        {
            result.Categorys.Add(_mapper.Map<GetItemByIdCategoryDto>(x.Category));
        });
        return await Result<GetItemByIdDto>.SuccessAsync(result);
    }
}

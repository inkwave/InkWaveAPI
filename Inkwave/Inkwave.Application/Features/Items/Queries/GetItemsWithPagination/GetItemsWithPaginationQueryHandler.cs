using Inkwave.Application.Extensions;
using Inkwave.Application.Features.Items.Queries.GetItemById;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Items.Queries.GetItemsWithPagination
{
    internal class GetItemsWithPaginationQueryHandler : IRequestHandler<GetItemsWithPaginationQuery, PaginatedResult<GetItemsWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetItemsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetItemsWithPaginationDto>> Handle(GetItemsWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.Repository<Item>().Entities
           .Include(x => x.SubDescription)
           .Include("ItemCategorys.Category")
           .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);

            var result = _mapper.Map<List<GetItemsWithPaginationDto>>(items.Data);

            items.Data.ForEach(item =>
            {
                item.ItemCategorys?.ToList().ForEach(x =>
                {
                    result.Where(i => i.Id == x.ItemId).ToList().ForEach(i => { i.Categorys.Add(_mapper.Map<GetItemByIdCategoryDto>(x.Category)); });
                });
            });
            PaginatedResult<GetItemsWithPaginationDto> paginated = new PaginatedResult<GetItemsWithPaginationDto>(items.Succeeded, result, items.Messages, items.TotalCount, query.PageNumber, query.PageSize);
            return paginated;
        }
    }

}

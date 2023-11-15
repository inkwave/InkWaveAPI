namespace Inkwave.Application.Features.Items.Queries.GetItemsWithPagination;


public record GetItemsWithPaginationQuery : IRequest<PaginatedResult<GetItemsWithPaginationDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetItemsWithPaginationQuery() { }

    public GetItemsWithPaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}

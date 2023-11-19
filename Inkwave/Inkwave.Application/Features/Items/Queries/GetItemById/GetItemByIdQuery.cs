using Inkwave.Application.Features.Items.Queries.GetItemById;

namespace Inkwave.Application.Features.Items.Queries.GetItemsWithPagination;

public record GetItemByIdQuery : IRequest<Result<GetItemByIdDto>>
{
    public GetItemByIdQuery(Guid Id)
    {
        this.Id = Id;
    }
    public Guid Id { get; set; }
}

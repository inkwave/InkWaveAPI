namespace Inkwave.Application.Features.Carts.Queries.GetCartInfo;

public record GetCartInfoDtoQuery : IRequest<Result<GetCartInfoDto>>
{
    public Guid UserId { get; set; }
}

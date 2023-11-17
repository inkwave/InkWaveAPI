namespace Inkwave.Application.Features.Address.Queries.GetAddressByUserId
{
    public class GetAddressByUserIdQuery : IRequest<Result<List<GetAddressByUserIdDto>>>
    {
        public Guid UserId { get; set; }

    }

}

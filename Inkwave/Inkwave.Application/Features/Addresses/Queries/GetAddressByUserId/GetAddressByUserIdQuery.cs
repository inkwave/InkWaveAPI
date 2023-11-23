namespace Inkwave.Application.Features.Addresses.Queries.GetAddressByUserId
{
    public class GetAddressByUserIdQuery : IRequest<Result<List<GetAddressByUserIdDto>>>
    {
        public Guid UserId { get; set; }

    }

}

namespace Inkwave.Application.Features.Addresses.Queries.GetAddressById
{
    public class GetAddressByIdQuery : IRequest<Result<GetAddressByIdDto>>
    {
        public Guid Id { get; set; }

    }

}
